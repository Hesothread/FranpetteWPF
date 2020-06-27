using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FranpetteServer.Services.FApplicationService.Models;

namespace FranpetteServer.Services.FApplicationService
{
    public class FApplicationService : AService, IFApplicationService
    {
        private readonly AirplaneContext _context;
        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FApplication> GetAllApplications()
        {
            throw new NotImplementedException();
        }

        public FApplication GetApplication(string applicationId)
        {
            throw new NotImplementedException();
        }

        public bool StartApplication(string applicationId, string userId)
        {
            throw new NotImplementedException();
        }

        public bool StopApplication(string applicationId, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
