using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using System;


namespace DataAccessLibrary.DbAccess
{
    //to extract interface, use ctrl+.
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(
            string storedProcedure,
            U parameters,
            string connectionId = "Default")
        {
            //Get the default connection string from configuration
            //using will close connection by itself

           // string str = "Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog = MinimalAPIDemoDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";

                using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            
                //using IDbConnection connection = new SqlConnection(str);
                return await connection.QueryAsync<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);      
            
        }

        public async Task SaveData<T>(
             string storedProcedure,
            T parameters,
            string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await connection.ExecuteAsync(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure);


        }


    }
}
