using Dapper;
using VanSync.Domain.Interfaces.Repositorys;
using VanSync.Domain.Models;

namespace VanSync.Infra.Data.Repositorys
{
    public class AdminRepositorys : BaseRepository, IAdminRepositorys
    {
        public AdminRepositorys(string connectionString) : base(connectionString) { }

        #region [USER]
        public async Task<UserModel> GetAllUser()
        {
            return await Connection.QueryFirstOrDefaultAsync<UserModel>(
                           "SELECT * FROM USER",
                           new DynamicParameters()
                         );
        }

        public async Task<UserModel> GetUser(Guid id)
        {
            return await Connection.QueryFirstOrDefaultAsync<UserModel>(
                           "SELECT * FROM USER WHERE ID = @ID",
                           new DynamicParameters(new { ID = id })
                         );
        }

        public async Task RegisterUser(UserModel userModel)
        {
            await Connection.ExecuteAsync(
                    @$"INSERT INTO USER(ID, NAME, AGE, STREET, NEIGHBORHOOD, NUMBERHOUSE, CITY, AMOUNTTOPAY)
                       VALUES(@ID, @NAME, @AGE, @STREET, @NEIGHBORHOOD, @NUMBERHOUSE, @CITY, @AMOUNTTOPAY)",
                    new DynamicParameters(userModel)
                  );
        }

        public async Task EditUser(UserModel userModel)
        {
            await Connection.ExecuteAsync(
                    @$"UPDATE USER SET NAME = @NAME, AGE = @AGE, STREET = @STREET, NEIGHBORHOOD = @NEIGHBORHOOD, NUMBERHOUSE = @NUMBERHOUSE, CITY = @CITY, AMOUNTTOPAY = @AMOUNTTOPAY
                       WHERE ID = @ID",
                    new DynamicParameters(userModel)
                  );
        }

        public async Task DeleteUser(Guid id)
        {
            await Connection.ExecuteAsync(
                    @$"DELETE FROM USER WHERE ID = @ID",
                    new DynamicParameters(new { ID = id })
                  );
        }
        #endregion [USER]

        #region [ATTENDANCE LIST]
        #endregion [ATTENDANCE LIST]
    }
}
