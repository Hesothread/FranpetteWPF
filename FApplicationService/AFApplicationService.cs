using FranpetteLib.Dto.FApplicationDto.Request;
using FranpetteLib.Dto.FApplicationDto.Response;
using FranpetteLib.Result;
using FranpetteServer.Services;
using FranpetteServer.Services.FApplicationService;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FranpetteServer.Services.FApplicationService
{
    public class AFApplicationService : AFranpetteService, IFApplicationService
    {
        public Task<Result> CreateApplicationRepository(Request_FApplicationCreateDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<IFormFile> DownlaodApplication(string applicationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Response_FApplicationGetInfoDto>> GetAllApplicationsInfo()
        {
            throw new System.NotImplementedException();
        }

        public Task<Response_FApplicationGetHashFileDto> GetApplicationHashFile(string applicationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Response_FApplicationGetInfoDto> GetApplicationInfo(string applicationId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> StartApplication(string applicationId, Request_FApplicationStartDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> StopApplication(string applicationId, Request_FApplicationStopDto request)
        {
            throw new System.NotImplementedException();
        }

        public Task<Result> UploadApplication(string applicationId, IFormFile file)
        {
            throw new System.NotImplementedException();
        }
    }
}
