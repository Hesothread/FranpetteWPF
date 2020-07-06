using FranpetteLib.Dto.FApplicationDto.Request;
using FranpetteLib.Dto.FApplicationDto.Response;
using FranpetteLib.Result;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FranpetteServer.Services.FApplicationService
{
    public abstract class AFApplicationService : AFranpetteService, IFApplicationService
    {
        public abstract Task<Result> CreateApplicationRepository(Request_FApplicationCreateDto request);

        public abstract Task<IFormFile> DownlaodApplication(string applicationId);

        public abstract Task<IEnumerable<Response_FApplicationGetInfoDto>> GetAllApplicationsInfo();

        public abstract Task<Response_FApplicationGetHashFileDto> GetApplicationHashFile(string applicationId);

        public abstract Task<Response_FApplicationGetInfoDto> GetApplicationInfo(string applicationId);

        public abstract Task<Result> StartApplication(string applicationId, Request_FApplicationStartDto request);

        public abstract Task<Result> StopApplication(string applicationId, Request_FApplicationStopDto request);

        public abstract Task<Result> UploadApplication(string applicationId, IFormFile file);
    }
}
