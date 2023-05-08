using VanSync.Domain.Interfaces.Repositorys;
using VanSync.Domain.Interfaces.Services;
using VanSync.Domain.Models;

namespace VanSync.Business.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepositorys _adminRepository;

        public AdminServices(IAdminRepositorys adminRepository)
        {
            _adminRepository = adminRepository;
        }

        #region [USER]
        public async Task<UserModel> GetAllUser()
            => await _adminRepository.GetAllUser();

        public async Task<UserModel> GetUser(Guid id)
            => await _adminRepository.GetUser(id);

        public async Task<ResultModel> RegisterUser(UserModel userModel)
        {
            if (Guid.Empty.Equals(userModel.Id))
                return new ResultModel() { Mensagem = "Usuário não existe.", Sucesso = false };

            await _adminRepository.RegisterUser(userModel);

            return new ResultModel() { Mensagem = "Usuário cadastrado com sucesso.", Sucesso = true };
        }

        public async Task<ResultModel> EditUser(UserModel userModel)
        {
            if (Guid.Empty.Equals(userModel.Id))
                return new ResultModel() { Mensagem = "Usuário não existe.", Sucesso = false };

            await _adminRepository.EditUser(userModel);

            return new ResultModel() { Mensagem = "Usuário alterado com sucesso.", Sucesso = true };
        }

        public async Task<ResultModel> DeleteUser(Guid id)
        {
            if (Guid.Empty.Equals(id))
                return new ResultModel() { Mensagem = "Usuário não existe.", Sucesso = false };

            await _adminRepository.DeleteUser(id);

            return new ResultModel() { Mensagem = "Usuário excluído com sucesso.", Sucesso = true };
        }
        #endregion [USER]

        #region [ATTENDANCE LIST]
        #endregion [ATTENDANCE LIST]
    }
}
