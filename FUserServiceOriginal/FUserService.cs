using System;
using System.Collections.Generic;
using Franpette.Services.FUserServices;

namespace FranpetteServer.Services.FUserService
{
    public class FUserService : AFUserService
    {
        private IFUserPersistanceModule _userPersistance;

        public FUserService(IFSessionModule sessionModule, IFUserPersistanceModule userPersistance)
        {
            _sessionModule = sessionModule;
            _userPersistance = userPersistance;
        }

        #region Interface IFUserService

        public int Create(FUser newUser)
        {
            throw new NotImplementedException();
        }

        public int Connect(FUser newUser)
        {
            throw new NotImplementedException();
        }

        public bool Disconnect(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public FUser GetUser(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Dispose

        public override void Dispose()
        {
        }
        #endregion
    }
}
