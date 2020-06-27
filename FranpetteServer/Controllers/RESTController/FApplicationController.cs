using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using FranpetteLib.Dto.FApplicationDto.Request;
using FranpetteLib.Dto.FApplicationDto.Response;
using FranpetteLib.MessageProvider;
using FranpetteLib.Result;
using FranpetteServer.Services.FApplicationService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FranpetteServer.Controllers.RESTController
{
    [ApiController]
    [Route("application")]
    public class FApplicationController : ControllerBase
    {
        private readonly ILogger<FApplicationController> _logger;
        private readonly IMessageProvider _messageProvider;

        private readonly IFApplicationService _applicationService;

        public FApplicationController(IMessageProvider messageProvider, ILogger<FApplicationController> logger, IFApplicationService applicationService)
        {
            _logger = logger;
            _applicationService = applicationService;
            _messageProvider = messageProvider;
        }

        #region Get about : Get .../application/version

        [HttpGet("About")]
        public IActionResult About()
        {
            return Ok("An API managing application for frampette comunity.");
        }

        #endregion

        #region Get version : Get .../application/version

        [HttpGet("version")]
        public IActionResult Version()
        {
            return Ok("Version 1.0.0");
        }

        #endregion

        #region Get All Application Info : Get .../application

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Response_FApplicationGetInfoDto>>> GetAllApplicationsInfo()
        {
            return Ok(await _applicationService.GetAllApplicationsInfo());
        }

        #endregion

        #region Get Application Info : Get .../application/{applicationId}

        [HttpGet("{applicationId}")]
        public async Task<ActionResult<Response_FApplicationGetInfoDto>> GetApplicationInfo(string applicationId)
        {
            var application = await _applicationService.GetApplicationInfo(applicationId);
            if (application == null)
            {
                return BadRequest(_messageProvider.Messages);   
            }
            else
            {
                return Ok(application);
            }
        }
        #endregion

        #region StartApplication : Post .../application/{applicationId}/start

        [HttpPost("{applicationId}/start")]
        public async Task<ActionResult<Response_FApplicationGetInfoDto>> StartApplication(string applicationId, [FromBody] Request_FApplicationStartDto request)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var result = await _applicationService.StartApplication(applicationId, request);
            if (result)
            {
                // Return 201 with the Location header indicating how to retrieve the resource, and the state of the resource after it was created
                return Ok(_applicationService.GetApplicationInfo(applicationId));
            }
            else
            {
                // There was some reason the resource does not exist in the database, so something was wrong with the request, return 400
                return BadRequest(_messageProvider.Messages);
            }
        }

        #endregion

        #region StopApplication : Post .../application/{applicationId}/stop

        [HttpPost("{applicationId}/stop")]
        public async Task<ActionResult<Response_FApplicationGetInfoDto>> StopApplication(string applicationId, [FromBody] Request_FApplicationStopDto request)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var result = await _applicationService.StopApplication(applicationId, request);
            if (result)
            {
                return Ok(_applicationService.GetApplicationInfo(applicationId));
            }
            else
            {
                return BadRequest(_messageProvider.Messages);
            }
        }

        #endregion

        #region Get Application HashFile : Get .../application/{applicationId}/hashfile

        [HttpGet("{applicationId}/hashfile")]
        public async Task<ActionResult<Response_FApplicationGetHashFileDto>> GetApplicationHashFile(string applicationId)
        {
            var application = await _applicationService.GetApplicationHashFile(applicationId);
            if (application == null)
            {
                return BadRequest(_messageProvider.Messages);
            }
            else
            {
                return Ok(application);
            }
        }

        #endregion

        #region Download Application : Get .../application/{applicationId}/download

        [HttpGet("{applicationId}/download")]
        public async Task<ActionResult<IFormFile>> DownloadApplication(string applicationId)
        {
            var file = await _applicationService.DownlaodApplication(applicationId);
            if (file == null)
            {
                return BadRequest(_messageProvider.Messages);
            }
            else
            {
                return Ok(file);
            }
        }

        #endregion

        #region Create Application Folder : Post .../application/{applicationId}/create

        [HttpPost("{applicationId}/create")]
        public async Task<ActionResult<Response_FApplicationGetInfoDto>> CreateApplicaitonRepository([FromBody] Request_FApplicationCreateDto request)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var result = await _applicationService.CreateApplicationRepository(request);
            if (result)
            {
                // Return 201 with the Location header indicating how to retrieve the resource, and the state of the resource after it was created
                return Created($"application/{(result as DataResult<Response_FApplicationGetInfoDto>)?.Data.Id}", new
                {
                    Data = (result as DataResult<Response_FApplicationGetInfoDto>)?.Data,
                    Messages = _messageProvider.Messages
                });
            }
            else
            {
                // There was some reason the resource does not exist in the database, so something was wrong with the request, return 400
                return BadRequest(_messageProvider.Messages);
            }
        }

        #endregion

        #region Update Application : Post .../application/{applicationId}/upload

        [HttpPost("{applicationId}/upload")]
        public async Task<ActionResult<Response_FApplicationGetInfoDto>> CreateApplicaitonRepository(string applicationId, [FromForm] IFormFile file)
        {
            using (var sr = new StreamReader(file.OpenReadStream()))
            {
                var content = await sr.ReadToEndAsync();
            }

            var result = await _applicationService.UploadApplication(applicationId, file);
            if (result)
            {
                return Ok(_applicationService.GetApplicationInfo(applicationId));
            }
            else
            {
                return BadRequest(_messageProvider.Messages);
            }
        }

        #endregion
    }
}