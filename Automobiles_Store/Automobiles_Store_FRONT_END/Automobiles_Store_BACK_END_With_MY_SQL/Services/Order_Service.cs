using Automobiles_Store_BACK_END_With_MY_SQL.Models;
using Automobiles_Store_BACK_END_With_MY_SQL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_MY_SQL.Services
{
    public class Order_Service
    {
        public Order_Repositories control;

        public Order_Service(string dataBase)
        {
            this.control = new Order_Repositories(dataBase);
        }

        public List<Order> lista()
        {
            return control.getAll();
        }
    }
}
