using Automobiles_Store_BACK_END_With_MY_SQL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Automobiles_Store_BACK_END_With_MY_SQL_TESTS._1_User_Tests
{
    public class User_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private User_Service service;
        public User_Tests(ITestOutputHelper output)
        {
            this.service = new User_Service("Tests");
            this.outputHelper = output;
        }

        //[Fact]
        public void test_afisare()
        {
            this.outputHelper.WriteLine(this.service.lista()[0].ToString());
        }

    }
}
