using FranpetteLib.Dto.FApplicationDto.Request;
using FranpetteLib.Dto.FApplicationDto.Response;
using FranpetteLib.Result;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FranpetteServer.Services.FApplicationService
{
    public interface IFApplicationService : IFranpetteService
    {
        // FApplicationDBService ApplicationService { get; }
        // FUserDBService UserService { get; }

        #region Application

        Task<IEnumerable<Response_FApplicationGetInfoDto>> GetAllApplicationsInfo();
        Task<Response_FApplicationGetInfoDto> GetApplicationInfo(string applicationId);
        Task<Result> StartApplication(string applicationId, Request_FApplicationStartDto request);
        Task<Result> StopApplication(string applicationId, Request_FApplicationStopDto request);
        Task<Response_FApplicationGetHashFileDto> GetApplicationHashFile(string applicationId);
        Task<IFormFile> DownlaodApplication(string applicationId);
        Task<Result> CreateApplicationRepository(Request_FApplicationCreateDto request);
        Task<Result> UploadApplication(string applicationId, IFormFile file);
        #endregion
    }
}
