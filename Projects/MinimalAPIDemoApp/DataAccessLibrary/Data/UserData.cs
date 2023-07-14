using DataAccessLibrary.DbAccess;
using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Data
{


    // This class will talk to DataAccess classes
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _db;

        public UserData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserModel>> GetUsers() =>
            _db.LoadData<UserModel, dynamic>(storedProcedure: "dbo.spUser_GetAll", new { });


        public async Task<UserModel?> GetUser(int id)
        {

            var results = await _db.LoadData<UserModel, dynamic>(
                storedProcedure: "dbo.spUser_Get",
                new { Id = id });

            return results.FirstOrDefault();
        }

        public Task InsertUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Insert", new { user.FirstName, user.LastName });

        public Task UpdateUser(UserModel user) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Update", new { user });

        public Task DeleteUser(int id) =>
            _db.SaveData(storedProcedure: "dbo.spUser_Delete", new { Id = id });


    }
}
