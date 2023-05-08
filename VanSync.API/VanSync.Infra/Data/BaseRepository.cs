using System.Data;
using System.Data.SqlClient;

namespace VanSync.Infra.Data
{
    public class BaseRepository
    {
        private string ConnecitonString { get; }

        public BaseRepository(string connecitonString)
        {
            ConnecitonString = connecitonString;
        }

        protected SqlConnection Connection => Setup(ConnecitonString);

        private SqlConnection Setup(string connectionString)
        {
            var conn = new SqlConnection(connectionString);

            if (conn.State != ConnectionState.Open)
                conn.Open();

            return conn;
        }
    }
}
