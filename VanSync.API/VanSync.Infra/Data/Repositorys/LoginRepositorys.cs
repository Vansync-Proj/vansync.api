using Dapper;
using VanSync.Domain.Interfaces.Repositorys;
using VanSync.Domain.Models;

namespace VanSync.Infra.Data.Repositorys
{
    public class LoginRepositorys : BaseRepository, ILoginRepositorys
    {
        public LoginRepositorys(string connectionString) : base(connectionString) { }

        public async Task<bool> EmailExists(string email)
        {
            return await Connection.QueryFirstOrDefaultAsync<bool>(
                           "SELECT 1 FROM USER WHERE EMAIL = @EMAIL",
                           new DynamicParameters(new { EMAIL = email })
                         );
        }

        public async Task Register(LoginModel loginModel)
        {
            await Connection.ExecuteAsync(
                    @$"INSERT INTO USER (ID, NAME, EMAIL, PASSWORD, DATEREGISTER)
                       VALUES (@ID, @NAME, @EMAIL, @PASSWORD, GETDATE())",
                    new DynamicParameters(loginModel)
                  );
        }

        public async Task<bool> GetUserLogin(string email, string passWord)
        {
            return await Connection.QueryFirstOrDefaultAsync<bool>(
                           "SELECT 1 FROM USER WHERE EMAIL = @EMAIL AND PASSWORD = @PASSWORD",
                           new DynamicParameters(new { EMAIL = email, PASSWORD = passWord })
                         );
        }

        public async Task AlterPassWord(AlterPassWordModel alterPassWordModel)
        {
            await Connection.ExecuteAsync(
                    @$"UPDATE USER SET PASSWORD = @NEWPASSWORD WHERE EMAIL = @EMAIL AND PASSWORD = @PASSWORD",
                    new DynamicParameters(alterPassWordModel)
                  );
        }
    }
}