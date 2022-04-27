using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_MY_SQL.Exceptions
{
    public class Order_Exception : Exception
    {
        public Order_Exception(string message) : base(message) { }
    }
}
