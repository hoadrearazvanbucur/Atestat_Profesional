using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE_TESTS._1_User_Tests
{
    public class User_Tests
    {
        private readonly ITestOutputHelper outputHelper;
        private Control_Users control;

        public User_Tests(ITestOutputHelper outputHelper)
        {
            this.control = new Control_Users("Tests");
            this.outputHelper = outputHelper;
        }

        //[Fact]
        //public void load_save_adding_removal()
        //{
        //    this.control.load();
        //    this.control.adding("111|11|111|1111");
        //    Assert.True(control.exist_Test("111|11|111|1111"));
        //    this.control.save();
        //    this.control.load();
        //    Assert.True(control.exist_Test("111|11|111|1111"));
        //    this.control.removal(new User("111|11|111|1111"));
        //    Assert.False(control.exist_Test("111|11|111|1111"));
        //    this.control.save();
        //}
        //[Fact]
        //public void clear()
        //{
        //    for (int i = 1; i <= 4; i++)
        //    {
        //        this.control.adding($"{i}|2|3|4");
        //        Assert.True(this.control.exist_Test($"{i}|2|3|4"));
        //    }
        //    Assert.False(this.control.Lista.listaGoala());
        //    this.control.clear();
        //    Assert.True(this.control.Lista.listaGoala());
        //}

        //[Fact]
        //public void show()
        //{
        //    for (int i = 1; i <= 4; i++)
        //    {
        //        this.control.adding($"{i}|2|3|4");
        //        Assert.True(this.control.exist_Test($"{i}|2|3|4"));
        //    }
        //    Assert.False(this.control.Lista.listaGoala());
        //    this.outputHelper.WriteLine(this.control.show());
        //    this.control.clear();
        //    Assert.True(this.control.Lista.listaGoala());
        //}

        //[Fact]
        //public void change()
        //{
        //    this.control.adding("111|11|111|1111");
        //    Assert.True(this.control.exist_Test("111|11|111|1111"));
        //    this.control.changeId(111, 222);
        //    this.control.changeAdmin(222, 2);
        //    this.control.changeName(222, "2");
        //    this.control.changePassword(222, "2");
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Id == 222);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Admin == 2);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Name == "2");
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(222)).Data.Password == "2");
        //    Assert.True(this.control.exist_Test("222|2|2|2"));
        //    this.control.removal(new User("222|2|2|2"));
        //    Assert.False(this.control.exist_Test("222|2|2|2"));
        //}

        //[Fact]
        //public void makeRemoveAdmin()
        //{
        //    this.control.adding("111|1|111|1111");
        //    Assert.True(this.control.exist_Test("111|1|111|1111"));
        //    this.control.makeRemoveAdmin(111, this.control.Lista.obtine(this.control.positionId(111)).Data.Admin);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(111)).Data.Admin == 0);
        //    this.control.makeRemoveAdmin(111, this.control.Lista.obtine(this.control.positionId(111)).Data.Admin);
        //    Assert.True(this.control.Lista.obtine(this.control.positionId(111)).Data.Admin == 1);
        //    this.control.removal(new User("111|1|111|1111"));
        //    Assert.False(this.control.exist_Test("111|1|111|1111"));
        //}

        //[Fact]
        //public void getId_getAdmin()
        //{
        //    this.control.adding("1111|12|111|1111");
        //    Assert.True(this.control.exist_Test("1111|12|111|1111"));
        //    Assert.True(this.control.getAdmin(this.control.Lista.obtine(this.control.positionId(1111)).Data.Name, this.control.Lista.obtine(this.control.positionId(1111)).Data.Password) == 12);
        //    Assert.True(this.control.getId(this.control.Lista.obtine(this.control.positionId(1111)).Data.Name, this.control.Lista.obtine(this.control.positionId(1111)).Data.Password) == 1111);
        //    this.control.removal(new User("1111|12|111|1111"));
        //    Assert.False(this.control.exist_Test("1111|21|111|1111"));
        //}

        //[Fact]
        //public void login()
        //{
        //    this.control.adding("1111|12|111|1111");
        //    Assert.True(this.control.exist_Test("1111|12|111|1111"));
        //    Assert.True(this.control.login_exist(this.control.Lista.obtine(this.control.positionId(1111)).Data.Name, this.control.Lista.obtine(this.control.positionId(1111)).Data.Password) == true);
        //    Assert.False(this.control.login_exist("123", "123") == true);
        //    this.control.removal(new User("1111|12|111|1111"));
        //    Assert.False(this.control.exist_Test("1111|21|111|1111"));
        //}

        //[Fact]
        //public void generationId()
        //{
        //    this.control.adding("111|1|1|1");
        //    Assert.True(this.control.exist_Test("111|1|1|1"));
        //    this.control.adding($"{this.control.generationId()}|1|1|1");
        //    Assert.True(this.control.exist_Test("112|1|1|1"));
        //    this.control.adding("154|1|1|1");
        //    Assert.True(this.control.exist_Test("154|1|1|1"));
        //    this.control.adding($"{this.control.generationId()}|1|1|1");
        //    Assert.True(this.control.exist_Test("155|1|1|1"));
        //    this.control.removal(new User("111|1|1|1"));
        //    Assert.False(this.control.exist_Test("111|1|1|1"));
        //    this.control.removal(new User("112|1|1|1"));
        //    Assert.False(this.control.exist_Test("112|1|1|1"));
        //    this.control.removal(new User("154|1|1|1"));
        //    Assert.False(this.control.exist_Test("154|1|1|1"));
        //    this.control.removal(new User("155|1|1|1"));
        //    Assert.False(this.control.exist_Test("155|1|1|1"));
        //}
    }
}
