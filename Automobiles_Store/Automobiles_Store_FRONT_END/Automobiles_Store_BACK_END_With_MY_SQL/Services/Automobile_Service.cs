using Automobiles_Store_BACK_END_With_MY_SQL.Models;
using Automobiles_Store_BACK_END_With_MY_SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_MY_SQL.Services
{
    public class Automobile_Service
    {
        public Automobile_Repositories control;

        public Automobile_Service(string dataBase)
        {
            this.control = new Automobile_Repositories(dataBase);
        }

        public List<Automobile> lista()
        {
            return control.getAll();
        }
    }
}
