using VanSync.Domain.Interfaces.Repositorys;
using VanSync.Domain.Interfaces.Services;

namespace VanSync.Business.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositorys _userRepositorys;

        public UserServices(IUserRepositorys userRepositorys)
        {
            _userRepositorys = userRepositorys;
        }
    }
}
