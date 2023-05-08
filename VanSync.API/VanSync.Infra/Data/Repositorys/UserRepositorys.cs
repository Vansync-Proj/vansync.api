using VanSync.Domain.Interfaces.Repositorys;

namespace VanSync.Infra.Data.Repositorys
{
    public class UserRepositorys : BaseRepository, IUserRepositorys
    {
        public UserRepositorys(string connectionString) : base(connectionString) { }
    }
}
