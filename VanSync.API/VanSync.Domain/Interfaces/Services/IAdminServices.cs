using VanSync.Domain.Models;

namespace VanSync.Domain.Interfaces.Services
{
    public interface IAdminServices
    {
        #region [USER]
        Task<UserModel> GetAllUser();
        Task<UserModel> GetUser(Guid id);
        Task<ResultModel> RegisterUser(UserModel userModel);
        Task<ResultModel> EditUser(UserModel userModel);
        Task<ResultModel> DeleteUser(Guid id);
        #endregion [USER]

        #region [ATTENDANCE LIST]
        #endregion [ATTENDANCE LIST]
    }
}
