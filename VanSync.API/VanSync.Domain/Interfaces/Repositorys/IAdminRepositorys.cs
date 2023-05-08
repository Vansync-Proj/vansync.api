using VanSync.Domain.Models;

namespace VanSync.Domain.Interfaces.Repositorys
{
    public interface IAdminRepositorys
    {
        #region [USER]
        Task<UserModel> GetAllUser();
        Task<UserModel> GetUser(Guid id);
        Task RegisterUser(UserModel userModel);
        Task EditUser(UserModel userModel);
        Task DeleteUser(Guid id);
        #endregion [USER]

        #region [ATTENDANCE LIST]
        #endregion [ATTENDANCE LIST]
    }
}
