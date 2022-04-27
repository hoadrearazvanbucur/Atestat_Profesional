using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE_TESTS._4_Integration_Tests
{
    public class Integration_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Control_Users controlUsers;
        private Control_Automobiles controlAutomobiles;
        private Control_Orders controlOrders;

        public Integration_Tests(ITestOutputHelper outputHelper)
        {
            this.controlUsers = new Control_Users("Tests");
            this.controlAutomobiles = new Control_Automobiles("Tests");
            this.controlOrders = new Control_Orders("Tests");
            this.outputHelper = outputHelper;
        }
        [Fact]
        public void integration()
        {
            User user1 = new User("1|2|3|4");
            User user2 = new User("11|22|33|44");
            this.controlUsers.adding(user1.ToString());
            this.controlUsers.adding(user2.ToString());
            this.outputHelper.WriteLine(controlUsers.show() + "\n\n");

            Automobile automobile1 = new Automobile("1|2|9|10|5|6|7");
            Automobile automobile2 = new Automobile("2|2|9|15|5|6|7");
            Automobile automobile3 = new Automobile("3|2|9|20|5|6|7");
            this.controlAutomobiles.adding(automobile1.ToString());
            this.controlAutomobiles.adding(automobile2.ToString());
            this.controlAutomobiles.adding(automobile3.ToString());
            this.outputHelper.WriteLine(controlAutomobiles.show() + "\n\n");

            Order order1 = new Order("1|1|2|1,2|2,2");
            Order order2 = new Order("2|11|1|3|3");
            this.controlOrders.adding(order1.ToString());
            this.controlOrders.adding(order2.ToString());
            this.outputHelper.WriteLine(controlOrders.show() + "\n\n");
            this.controlOrders.Lista.obtine(this.controlOrders.positionId(1)).Data.addAutomobile(9, 9);
            this.outputHelper.WriteLine(controlOrders.show() + "\n\n");
            this.controlOrders.Lista.obtine(this.controlOrders.positionId(1)).Data.delAutomobile(9);
            this.outputHelper.WriteLine(controlOrders.show() + "\n\n");

            this.controlUsers.removal(new User("1|2|3|4"));
            this.outputHelper.WriteLine(controlUsers.show() + "\n\n");
        }


    }
}
