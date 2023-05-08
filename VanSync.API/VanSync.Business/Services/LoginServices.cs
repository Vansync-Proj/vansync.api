using System.Security.Cryptography;
using System.Text;
using VanSync.Domain.Interfaces.Repositorys;
using VanSync.Domain.Interfaces.Services;
using VanSync.Domain.Models;

namespace VanSync.Business.Services
{
    public class LoginServices : ILoginServices
    {
        private readonly ILoginRepositorys _loginRepository;

        public LoginServices(ILoginRepositorys loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<ResultModel> Register(LoginModel loginModel)
        {
            if (!await _loginRepository.EmailExists(loginModel.Email))
            {
                if (!loginModel.Password.Equals(loginModel.ConfirmPassword))
                    return new ResultModel() { Mensagem = "Senhas não conferem.", Sucesso = false };

                loginModel.Password = CriptPassWord(loginModel.Password);
                await _loginRepository.Register(loginModel);

                return new ResultModel() { Mensagem = "Usuário cadastrado com sucesso.", Sucesso = true };
            }

            return new ResultModel() { Mensagem = "Usuário ja existe no sistema.", Sucesso = false };
        }

        public async Task<ResultModel> Login(string email, string passWord)
        {
            passWord = CriptPassWord(passWord);
            bool loginIsTrue = await _loginRepository.GetUserLogin(email, passWord);

            if (loginIsTrue)
                return new ResultModel() { Mensagem = "Bem vindo.", Sucesso = false };

            return new ResultModel() { Mensagem = "Dados incorretos.", Sucesso = false };
        }

        public async Task<ResultModel> AlterPassWord(AlterPassWordModel alterPassWordModel)
        {
            if (!await _loginRepository.EmailExists(alterPassWordModel.Email))
            {
                if (!alterPassWordModel.NewPassword.Equals(alterPassWordModel.ConfirmPasswordNewPassWord))
                    return new ResultModel() { Mensagem = "Novas senhas não conferem.", Sucesso = false };

                alterPassWordModel.OldPassword = CriptPassWord(alterPassWordModel.OldPassword);
                if (await _loginRepository.GetUserLogin(alterPassWordModel.Email, alterPassWordModel.OldPassword))
                {
                    alterPassWordModel.NewPassword = CriptPassWord(alterPassWordModel.NewPassword);
                    await _loginRepository.AlterPassWord(alterPassWordModel);

                    return new ResultModel() { Mensagem = "Senha alterada com sucesso.", Sucesso = false };
                }
            }

            return new ResultModel() { Mensagem = "Dados incorretos.", Sucesso = false };
        }

        private string CriptPassWord(string passWord)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(passWord));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
