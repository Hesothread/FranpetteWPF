using Franpette.Services.FUserServices.Models;
using System.Collections.Generic;

namespace Franpette.Services.FUserServices
{
    public interface IFUserService : IService
    {
        #region User

        IEnumerable<FUser> GetAllUsers();
        FUser GetUser(int userId);
        int Connect(FUser newUser);
        bool Disconnect(int userId);

        #endregion
    }
}
