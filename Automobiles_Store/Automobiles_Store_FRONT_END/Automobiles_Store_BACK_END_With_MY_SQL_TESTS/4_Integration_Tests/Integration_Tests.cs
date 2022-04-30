using Automobiles_Store_BACK_END_With_MY_SQL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Automobiles_Store_BACK_END_With_MY_SQL_TESTS._4_Integration_Tests
{
    public class Integration_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private User_Service userService;
        private Automobile_Service automobileService;
        private Order_Service orderService;
        public Integration_Tests(ITestOutputHelper output)
        {
            this.automobileService = new Automobile_Service("Tests");
            this.userService = new User_Service("Tests");
            this.orderService = new Order_Service("Tests");
            this.outputHelper = output;
        }

        //[Fact]
        public void test_afisare()
        {
            this.outputHelper.WriteLine(this.orderService.lista()[0].ToString());
            this.outputHelper.WriteLine(this.automobileService.lista()[0].ToString());
            this.outputHelper.WriteLine(this.userService.lista()[0].ToString());
        }
    }
}
