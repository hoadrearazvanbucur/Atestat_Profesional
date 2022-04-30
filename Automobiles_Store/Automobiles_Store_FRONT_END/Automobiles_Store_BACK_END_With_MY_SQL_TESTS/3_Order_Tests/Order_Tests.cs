using Automobiles_Store_BACK_END_With_MY_SQL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Automobiles_Store_BACK_END_With_MY_SQL_TESTS._3_Order_Tests
{
    public class Order_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Order_Service service;
        public Order_Tests(ITestOutputHelper output)
        {
            this.service = new Order_Service("Tests");
            this.outputHelper = output;
        }

        //[Fact]
        public void test_afisare()
        {
            this.outputHelper.WriteLine(this.service.lista()[0].ToString());
        }
    }
}
