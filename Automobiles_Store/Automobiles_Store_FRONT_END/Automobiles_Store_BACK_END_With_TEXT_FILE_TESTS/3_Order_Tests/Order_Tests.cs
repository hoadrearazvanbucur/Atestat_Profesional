using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;
using GENERIC_COLLECTIONS;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE_TESTS._3_Order_Tests
{
    public class Order_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Control_Orders control;

        public Order_Tests(ITestOutputHelper outputHelper)
        {
            this.control = new Control_Orders("Tests");
            this.outputHelper = outputHelper;
        }
        [Fact]
        public void load_save_adding_removal()
        {
            this.control.load();
            this.control.adding("111|2|2|1,2|3,4");
            Assert.True(this.control.exist_Test("111|2|2|1,2|3,4"));
            this.control.save();
            this.control.load();
            Assert.True(control.exist_Test("111|2|2|1,2|3,4"));
            this.control.removal(new Order("111|2|2|1,2|3,4"));
            Assert.False(control.exist_Test("111|2|2|1,2|3,4"));
            this.control.save();
        }

        [Fact]
        public void clear()
        {
            for (int i = 1; i <= 4; i++)
            {
                this.control.adding($"{i}|2|2|1,2|3,4");
                Assert.True(this.control.exist_Test($"{i}|2|2|1,2|3,4"));
            }
            Assert.False(this.control.Lista.listaGoala());
            this.control.clear();
            Assert.True(this.control.Lista.listaGoala());
        }

        [Fact]
        public void show()
        {
            for (int i = 1; i <= 4; i++)
            {
                this.control.adding($"{i}|2|2|1,2|3,4");
                Assert.True(this.control.exist_Test($"{i}|2|2|1,2|3,4"));
            }
            Assert.False(this.control.Lista.listaGoala());
            this.outputHelper.WriteLine(this.control.show());
            this.control.clear();
            Assert.True(this.control.Lista.listaGoala());
        }

        [Fact]
        public void change()
        {
            this.control.adding("111|2|2|1,2|3,4");
            Assert.True(this.control.exist_Test("111|2|2|1,2|3,4"));
            this.control.changeId(111, 222);
            this.control.changeId_user(222, 22);
            this.control.changeOrderSize(222, 3);
            this.control.changeAutomobiles_ID(222, new int[] { 11, 22, 33 });
            this.control.changeAmounts(222, new int[] { 111, 222, 333 });
            Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Id == 222);
            Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Id_user == 22);
            Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.OrderSize == 3);
            int[] newAutomobiles_ID = new int[] { 11, 22, 33 };
            int[] newAmounts = new int[] { 111, 222, 333 };
            for (int i = 0; i < this.control.Lista.obtine(this.control.positionId(222)).Data.OrderSize; i++)
            {
                Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Automobile_ID[i] == newAutomobiles_ID[i]);
                Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Amounts[i] == newAmounts[i]);
            }
            Assert.True(this.control.exist_Test("222|22|3|11,22,33|111,222,333"));
            this.control.removal(new Order("222|22|3|11,22,33|111,222,333"));
            Assert.False(this.control.exist_Test("222|22|3|11,22,33|111,222,333"));
        }

        [Fact]
        public void getOrderList()
        {
            for (int i = 1; i <= 4; i++)
            {
                this.control.adding($"{i}|{i + 1}|2|1,2|3,4");
                Assert.True(this.control.exist_Test($"{i}|{i + 1}|2|1,2|3,4"));
            }
            this.control.adding("5|3|1|9|9");
            Assert.True(this.control.exist_Test("5|3|1|9|9"));
            this.control.adding("6|3|1|99|99");
            Assert.True(this.control.exist_Test("6|3|1|99|99"));
            this.control.adding("7|5|1|99|99");
            Assert.True(this.control.exist_Test("7|5|1|99|99"));
            ILista<Order> newList = this.control.getOrderList(3);
            string[] text = new string[] { "2|3|2|1,2|3,4", "5|3|1|9|9", "6|3|1|99|99" };
            for (int i = 0; i < newList.dimensiune(); i++)
                Assert.True(newList.obtine(i).Data.ToString() == text[i]);
            newList = this.control.getOrderList(2);
            text = new string[] { "1|2|2|1,2|3,4" };
            for (int i = 0; i < newList.dimensiune(); i++)
                Assert.True(newList.obtine(i).Data.ToString() == text[i]);
            newList = this.control.getOrderList(5);
            text = new string[] { "4|5|2|1,2|3,4", "7|5|1|99|99" };
            for (int i = 0; i < newList.dimensiune(); i++)
                Assert.True(newList.obtine(i).Data.ToString() == text[i]);
            newList = this.control.getOrderList(1);
            Assert.True(newList.listaGoala());
            Assert.False(this.control.Lista.listaGoala());
            this.control.clear();
            Assert.True(this.control.Lista.listaGoala());
        }

        [Fact]
        public void getOrderPrice()
        {
            Order order1 = new Order("1|1|2|1,3|1,1");
            Order order2 = new Order("1|1|2|2,1|3,5");
            Control_Automobiles control_automobile = new Control_Automobiles("Tests");
            control_automobile.adding("1|2|9|5.5|5|6|7");
            control_automobile.adding("2|2|9|10|5|6|7");
            control_automobile.adding("3|2|9|25|5|6|7");
            Assert.True(this.control.getOrderPrice(order1, control_automobile).ToString() == "12");
            Assert.True(this.control.getOrderPrice(order2, control_automobile).ToString() == "48");
        }

        [Fact]
        public void canBeBought()
        {
            Order order1 = new Order("1|1|2|1,3|9,9");
            Order order2 = new Order("1|1|2|2,1|3,5");
            Control_Automobiles control_automobile = new Control_Automobiles("Tests");
            control_automobile.adding("1|2|5|5.5|5|6|7");
            control_automobile.adding("2|2|9|10|5|6|7");
            control_automobile.adding("3|2|9|25|5|6|7");
            Assert.True(this.control.canBeBought(order1, control_automobile) == false);
            Assert.True(this.control.canBeBought(order2, control_automobile) == true);
        }

        [Fact]
        public void generationId()
        {
            this.control.adding("111|2|2|1,2|3,4");
            Assert.True(this.control.exist_Test("111|2|2|1,2|3,4"));
            this.control.adding($"{this.control.generationId()}|2|2|1,2|3,4");
            Assert.True(this.control.exist_Test("112|2|2|1,2|3,4"));
            this.control.adding("154|2|2|1,2|3,4");
            Assert.True(this.control.exist_Test("154|2|2|1,2|3,4"));
            this.control.adding($"{this.control.generationId()}|2|2|1,2|3,4");
            Assert.True(this.control.exist_Test("155|2|2|1,2|3,4"));
            this.control.removal(new Order("111|2|2|1,2|3,4"));
            Assert.False(this.control.exist_Test("111|2|2|1,2|3,4"));
            this.control.removal(new Order("112|2|2|1,2|3,4"));
            Assert.False(this.control.exist_Test("112|2|2|1,2|3,4"));
            this.control.removal(new Order("154|2|2|1,2|3,4"));
            Assert.False(this.control.exist_Test("154|2|2|1,2|3,4"));
            this.control.removal(new Order("155|2|2|1,2|3,4"));
            Assert.False(this.control.exist_Test("155|2|2|1,2|3,4"));
        }

        [Fact]
        public void objectTest()
        {
            Order order1 = new Order("1|1|2|1,2|3,4");
            Assert.True(order1.Equals(new Order("1|1|2|1,2|3,4")) == true);
            Assert.True(order1.Equals(new Order("1|1|2|1,2|3,5")) == false);
            order1.addAutomobile(9, 9);
            Assert.True(order1.Equals(new Order("1|1|3|1,2,9|3,4,9")) == true);
            order1.addAutomobile(3, 3);
            Assert.True(order1.Equals(new Order("1|1|4|1,2,9,3|3,4,9,3")) == true);
            order1.delAutomobile(1);
            Assert.True(order1.Equals(new Order("1|1|3|2,9,3|4,9,3")) == true);
            order1.delAutomobile(2);
            Assert.True(order1.Equals(new Order("1|1|2|9,3|9,3")) == true);
            Assert.True(order1.findAutomobile(9) == true);
            Assert.True(order1.findAutomobile(1) == false);
            Assert.True(order1.ToString() == "1|1|2|9,3|9,3");
            Assert.True(order1.ToString() != "1|1|2|9,3|9,4");
        }
    }
}
