using VanSync.Domain.Models;

namespace VanSync.Domain.Interfaces.Services
{
    public interface ILoginServices
    {
        Task<ResultModel> Register(LoginModel loginModel);
        Task<ResultModel> Login(string email, string passWord);
        Task<ResultModel> AlterPassWord(AlterPassWordModel alterPassWordModel);
    }
}
