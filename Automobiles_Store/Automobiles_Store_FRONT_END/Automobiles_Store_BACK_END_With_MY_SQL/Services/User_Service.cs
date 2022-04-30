using Automobiles_Store_BACK_END_With_MY_SQL.Models;
using Automobiles_Store_BACK_END_With_MY_SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_MY_SQL.Services
{
    public class User_Service
    {
        public User_Repositories control;

        public User_Service(string dataBase)
        {
            this.control = new User_Repositories(dataBase);
        }

        public List<User> lista()
        {
            return control.getAll();
        }
    }
}
