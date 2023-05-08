using VanSync.Domain.Models;

namespace VanSync.Domain.Interfaces.Repositorys
{
    public interface ILoginRepositorys
    {
        Task<bool> EmailExists(string email);
        Task Register(LoginModel loginModel);
        Task<bool> GetUserLogin(string email, string passWord);
        Task AlterPassWord(AlterPassWordModel alterPassWordModel);
    }
}
