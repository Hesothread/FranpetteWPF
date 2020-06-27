using Franpette.Services.FUserServices.Models;
using System;
using System.Collections.Generic;

namespace Franpette.Services.FUserServices
{
    public abstract class AFUserService : AService, IFUserService
    {
        #region  User

        public virtual IEnumerable<FUser> DoGetAllUsers()
        {
            throw new NotImplementedException("DoGetAllUsers not implemented");
        }

        public virtual FUser DoGetUser(int userId)
        {
            throw new NotImplementedException("DoGetUser not implemented");
        }

        public virtual int DoConnect(FUser newUser)
        {
            throw new NotImplementedException("DoConnect not implemented");
        }

        public virtual bool DoDisconnect(int userId)
        {
            throw new NotImplementedException("DoDisconnect not implemented");
        }

        #endregion

        #region Interface User

        public IEnumerable<FUser> GetAllUsers()
        {
            return DoGetAllUsers();
        }

        public FUser GetUser(int userId)
        {
            return DoGetUser(userId);
        }

        public int Connect(FUser newUser)
        {
            return DoConnect(newUser);
        }

        public bool Disconnect(int userId)
        {
            return DoDisconnect(userId);
        }

        #endregion


        #region Dispose

        public override void Dispose()
        {

        }
        #endregion
    }
}
