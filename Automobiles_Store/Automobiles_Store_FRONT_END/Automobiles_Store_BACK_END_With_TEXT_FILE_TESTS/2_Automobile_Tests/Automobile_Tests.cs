using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE_TESTS._2_Automobile_Tests
{
    public class Automobile_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Control_Automobiles control;

        public Automobile_Tests(ITestOutputHelper outputHelper)
        {
            this.control = new Control_Automobiles("Tests");
            this.outputHelper = outputHelper;
        }

        //public void load_save_adding_removal()
        //{
        //    this.control.load();
        //    this.control.adding("111|2|3|4|5|6|7");
        //    Assert.True(this.control.exist_Test("111|2|3|4|5|6|7"));
        //    this.control.save();
        //    this.control.load();
        //    Assert.True(control.exist_Test("111|2|3|4|5|6|7"));
        //    this.control.removal(new Automobile("111|2|3|4|5|6|7"));
        //    Assert.False(control.exist_Test("111|2|3|4|5|6|7"));
        //    this.control.save();
        //}

        //public void change()
        //{
        //    this.control.adding("111|2|3|4|5|6|7");
        //    Assert.True(this.control.exist_Test("111|2|3|4|5|6|7"));
        //    this.control.changeId(111, 222);
        //    this.control.changeKm(222, 22);
        //    this.control.changeAmount(222, 33);
        //    this.control.changePrice(222, 44);
        //    this.control.changeBrand(222, "55");
        //    this.control.changeModel(222, "66");
        //    this.control.changeColor(222, "77");
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Id == 222);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Km == 22);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Amount == 33);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Price == 44);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Brand == "55");
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Model == "66");
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Color == "77");
        //    Assert.True(this.control.exist_Test("222|55|66|77|22|44|33"));
        //    this.control.removal(new Automobile("222|55|66|77|22|44|33"));
        //    Assert.False(this.control.exist_Test("222|55|66|77|22|44|33"));
        //}

        //public void clear()
        //{
        //    for (int i = 1; i <= 4; i++)
        //    {
        //        this.control.adding($"{i}|2|3|4|5|6|7");
        //        Assert.True(this.control.exist_Test($"{i}|2|3|4|5|6|7"));
        //    }
        //    Assert.False(this.control.Lista.listaGoala());
        //    this.control.clear();
        //    Assert.True(this.control.Lista.listaGoala());
        //}

        //public void show()
        //{
        //    for (int i = 1; i <= 4; i++)
        //    {
        //        this.control.adding($"{i}|2|3|4|5|6|7");
        //        Assert.True(this.control.exist_Test($"{i}|2|3|4|5|6|7"));
        //    }
        //    Assert.False(this.control.Lista.listaGoala());
        //    this.outputHelper.WriteLine(this.control.show());
        //    this.control.clear();
        //    Assert.True(this.control.Lista.listaGoala());
        //}

        //public void generationId()
        //{
        //    this.control.adding("111|1|1|1|1|1|1");
        //    Assert.True(this.control.exist_Test("111|1|1|1|1|1|1"));
        //    this.control.adding($"{this.control.generationId()}|1|1|1|1|1|1");
        //    Assert.True(this.control.exist_Test("112|1|1|1|1|1|1"));
        //    this.control.adding("154|1|1|1|1|1|1");
        //    Assert.True(this.control.exist_Test("154|1|1|1|1|1|1"));
        //    this.control.adding($"{this.control.generationId()}|1|1|1|1|1|1");
        //    Assert.True(this.control.exist_Test("155|1|1|1|1|1|1"));
        //    this.control.removal(new Automobile("111|1|1|1|1|1|1"));
        //    Assert.False(this.control.exist_Test("111|1|1|1|1|1|1"));
        //    this.control.removal(new Automobile("112|1|1|1|1|1|1"));
        //    Assert.False(this.control.exist_Test("112|1|1|1|1|1|1"));
        //    this.control.removal(new Automobile("154|1|1|1|1|1|1"));
        //    Assert.False(this.control.exist_Test("154|1|1|1|1|1|1"));
        //    this.control.removal(new Automobile("155|1|1|1|1|1|1"));
        //    Assert.False(this.control.exist_Test("155|1|1|1|1|1|1"));
        //}

        //public void objectTest()
        //{
        //    Automobile automobile1 = new Automobile("1|2|3|4|5|6|7");
        //    Assert.True(automobile1.Equals(new Automobile("1|2|3|4|5|6|7")) == true);
        //    Assert.True(automobile1.Equals(new Automobile("1|2|3|4|5|6|9")) == false);
        //    Assert.True(automobile1.ToString() == "1|2|3|4|5|6|7");
        //    Assert.True(automobile1.ToString() != "1|2|3|4|5|6|10");
        //}

    }
}
