using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using HikingTrails.Models;
 
namespace HikingTrails.Factory
{
    public class UserFactory : IFactory<Trail>
    {
        private string connectionString;
        public UserFactory()
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=trails;SslMode=None";
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }

        public void Add(Trail hike)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO entries (name, description, length, elvchange, longitude, latitude, created_at, updated_at) VALUES (@Name, @Description, @Length, @ElevationChange, @Longitude, @Latitude, NOW(), NOW())";
                dbConnection.Open();
                dbConnection.Execute(query, hike);
            }
        }

        
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM entries");
            }
        }
        public IEnumerable<Trail> GetSingleTrail(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query = $"SELECT * FROM entries WHERE id={id}";
                dbConnection.Open();
                return dbConnection.Query<Trail>(query);
            }
        }
    }
}