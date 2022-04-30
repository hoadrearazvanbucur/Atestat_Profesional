using Automobiles_Store_BACK_END_With_MY_SQL.Models;
using DATA_ACCES;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_MY_SQL.Repositories
{
    public class User_Repositories
    {
        private readonly string connectionString;
        private DataAcces db;

        public User_Repositories(string dataBase)
        {
            db = new DataAcces();
            var builder = new ConfigurationBuilder().SetBasePath
            (@"").AddJsonFile("appsettings.json");
            var config = builder.Build();
            this.connectionString = config.GetConnectionString(dataBase);
        }

        public List<User> getAll()
        {
            string sql = "select * from user";
            return db.LoadData <User, dynamic > (sql, new { }, connectionString);
        }

    }
}
