using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;
using Xunit;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Exceptions;

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

        [Fact]
        public void loadData()
        {
            this.outputHelper.WriteLine(this.control.afisare());
            Assert.True(this.control.listaGoala() == true);
        }

        [Fact]
        public void saveData()
        {
            Assert.True(this.control.listaGoala() == true);
            this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand1|Model1|Color1|2|3|4"));
            Assert.True(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 1);
            this.control.saveData();
            this.control.loadData();
            this.control.stergerePozitie(0);
            Assert.False(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void path()
        {
            this.outputHelper.WriteLine(this.control.path());
        }

        [Fact]
        public void obtineAutomobilDupaId()
        {
            Assert.True(this.control.listaGoala() == true);
            this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand1|Model1|Color1|2|3|4"));
            Assert.True(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 1);
            this.control.saveData();
            this.control.loadData();
            Assert.True(this.control.obtineAutomobilDupaId(1).ToString().Equals(new Automobile("1|Brand1|Model1|Color1|2|3|4").ToString()));
            Assert.Equal("Nu exista un automobil cu id-ul acesta", Assert.Throws<Automobile_Exception>(() => this.control.obtineAutomobilDupaId(2)).Message);
            this.control.stergerePozitie(0);
            Assert.False(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void obtineIdDupaAutomobil()
        {
            Assert.True(this.control.listaGoala() == true);
            this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand1|Model1|Color1|2|3|4"));
            Assert.True(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 1);
            this.control.saveData();
            this.control.loadData();
            Assert.True(this.control.obtineIdDupaAutomobil(new Automobile("1|Brand1|Model1|Color1|2|3|4")).ToString().Equals("1"));
            Assert.Equal("Acest automobil nu exista", Assert.Throws<Automobile_Exception>(() => this.control.obtineIdDupaAutomobil(new Automobile("2|Brand2|Model2|Color2|3|4|5"))).Message);
            this.control.stergerePozitie(0);
            Assert.False(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void generareId()
        {
            Assert.True(this.control.listaGoala() == true);
            this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand1|Model1|Color1|2|3|4"));
            Assert.True(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.dimensiune() == 1);
            this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand2|Model2|Color2|3|4|5"));
            Assert.True(this.control.exista(new Automobile("2|Brand2|Model2|Color2|3|4|5")) == true);
            Assert.True(this.control.dimensiune() == 2);
            this.control.adaugareSfarsit(new Automobile("7|Brand3|Model3|Color3|4|5|6"));
            Assert.True(this.control.exista(new Automobile("7|Brand3|Model3|Color3|4|5|6")) == true);
            Assert.True(this.control.dimensiune() == 3);
            this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand4|Model4|Color4|5|6|7"));
            Assert.True(this.control.exista(new Automobile("8|Brand4|Model4|Color4|5|6|7")) == true);
            Assert.True(this.control.dimensiune() == 4);
            for (int i = 1; i <= 4; i++)
                this.control.stergerePozitie(0);
            Assert.False(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.False(this.control.exista(new Automobile("2|Brand2|Model2|Color2|3|4|5")) == true);
            Assert.False(this.control.exista(new Automobile("7|Brand3|Model3|Color3|4|5|6")) == true);
            Assert.False(this.control.exista(new Automobile("8|Brand4|Model4|Color4|5|6|7")) == true);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void maximId()
        {
            Assert.True(this.control.listaGoala() == true);
            this.control.adaugareSfarsit(new Automobile("3|Brand3|Model3|Color3|4|5|6"));
            Assert.True(this.control.exista(new Automobile("3|Brand3|Model3|Color3|4|5|6")) == true);
            Assert.True(this.control.dimensiune() == 1);
            Assert.True(this.control.maximId() == 3);
            this.control.adaugareSfarsit(new Automobile("1|Brand1|Model1|Color1|2|3|4"));
            Assert.True(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == true);
            Assert.True(this.control.dimensiune() == 2);
            Assert.True(this.control.maximId() == 3);
            this.control.adaugareSfarsit(new Automobile("6|Brand6|Model6|Color6|7|8|9"));
            Assert.True(this.control.exista(new Automobile("6|Brand6|Model6|Color6|7|8|9")) == true);
            Assert.True(this.control.dimensiune() == 3);
            Assert.True(this.control.maximId() == 6);
            this.control.adaugareSfarsit(new Automobile("4|Brand4|Model4|Color4|5|6|7"));
            Assert.True(this.control.exista(new Automobile("4|Brand4|Model4|Color4|5|6|7")) == true);
            Assert.True(this.control.dimensiune() == 4);
            Assert.True(this.control.maximId() == 6);
            Assert.True(this.control.listaGoala() == false);
            this.control.saveData();
            this.control.loadData();
            for (int i = 1; i <= 4; i++)
                this.control.stergerePozitie(0);
            Assert.True(this.control.exista(new Automobile("3|Brand3|Model3|Color3|4|5|6")) == false);
            Assert.True(this.control.exista(new Automobile("1|Brand1|Model1|Color1|2|3|4")) == false);
            Assert.True(this.control.exista(new Automobile("6|Brand6|Model6|Color6|7|8|9")) == false);
            Assert.True(this.control.exista(new Automobile("4|Brand4|Model4|Color4|5|6|7")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }


        [Fact]
        public void pozitieId()
        {
            Assert.True(this.control.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 4);
            this.control.saveData();
            this.control.loadData();
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.pozitieId(i) == i - 1);
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest id nu exista", Assert.Throws<Automobile_Exception>(() => this.control.pozitieId(i + 4)).Message);
            for (int i = 1; i <= 4; i++)
                this.control.stergerePozitie(0);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void existaId()
        {
            Assert.True(this.control.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 4);
            this.control.saveData();
            this.control.loadData();
           for (int i = 1; i <= 4; i++)
                Assert.True(this.control.existaId(i) == true);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.existaId(i+4) == false);
            for (int i = 1; i <= 4; i++)
                this.control.stergerePozitie(0);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void adaugareSfarsit()
        {
            Assert.True(this.control.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 4);
            this.control.saveData();
            this.control.loadData();
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest automobil exista deja", Assert.Throws<Automobile_Exception>(() => this.control.adaugareSfarsit(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"))).Message);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.pozitieId(i) == i - 1);
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest id nu exista", Assert.Throws<Automobile_Exception>(() => this.control.pozitieId(i + 4)).Message);
            for (int i = 1; i <= 4; i++)
                this.control.stergerePozitie(0);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void adaugareInceput()
        {
            Assert.True(this.control.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.control.adaugareInceput(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 4);
            this.control.saveData();
            this.control.loadData();
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest automobil exista deja", Assert.Throws<Automobile_Exception>(() => this.control.adaugareInceput(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"))).Message);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.pozitieId(i) == 4 - i);
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest id nu exista", Assert.Throws<Automobile_Exception>(() => this.control.pozitieId(i + 4)).Message);
            for (int i = 1; i <= 4; i++)
                this.control.stergerePozitie(0);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void adaugarePozitie()
        {
            Assert.True(this.control.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 4);
            this.control.saveData();
            this.control.loadData();
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest automobil exista deja", Assert.Throws<Automobile_Exception>(() => this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"))).Message);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.pozitieId(i) == i - 1);
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest id nu exista", Assert.Throws<Automobile_Exception>(() => this.control.pozitieId(i + 4)).Message);
            int k = 0;
            for (int i = 5; i <= 8; i++)
                this.control.adaugarePozitie(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"), i - 5+k++);
            for (int i = 1; i <= 8; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            k = 0;
            for (int i = 5; i <= 8; i++)
                Assert.Equal("Acest automobil exista deja", Assert.Throws<Automobile_Exception>(() => this.control.adaugarePozitie(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"),i-5+k++)).Message);
            this.control.adaugarePozitie(new Automobile($"{this.control.generareId()}|Brand9|Model9|Color9|10|11|12"), this.control.dimensiune());
            Assert.True(this.control.exista(new Automobile("9|Brand9|Model9|Color9|10|11|12")) == true);
            Assert.Equal("Acest automobil exista deja", Assert.Throws<Automobile_Exception>(() => this.control.adaugarePozitie(new Automobile($"{this.control.generareId()}|Brand9|Model9|Color9|10|11|12"), this.control.dimensiune())).Message);
            Assert.Equal("Nu putem adauga pe aceasta pozitie", Assert.Throws<Automobile_Exception>(() => this.control.adaugarePozitie(new Automobile($"{this.control.generareId()}|Brand10|Model10|Color10|11|12|13"), this.control.dimensiune()+1)).Message);
            for (int i = 1; i <= 9; i++)
                this.control.stergerePozitie(0);
            for (int i = 1; i <= 9; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void stergereData()
        {
            Assert.True(this.control.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            for (int i = 1; i <= 4; i++)
                Assert.Equal("Acest automobil exista deja", Assert.Throws<Automobile_Exception>(() => this.control.adaugareSfarsit(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"))).Message);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.pozitieId(i) == i - 1);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 4);
            this.control.saveData();
            this.control.loadData(); 
            for (int i = 1; i <= 4; i++)
                this.control.stergereData(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void stergerePozitie()
        {
            Assert.True(this.control.listaGoala() == true);
            for (int i = 1; i <= 4; i++)
                this.control.adaugareSfarsit(new Automobile($"{this.control.generareId()}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}"));
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == true);
            Assert.True(this.control.listaGoala() == false);
            Assert.True(this.control.dimensiune() == 4);
            this.control.saveData();
            this.control.loadData();
            for (int i = 1; i <= 4; i++)
                this.control.stergerePozitie(0);
            for (int i = 1; i <= 4; i++)
                Assert.True(this.control.exista(new Automobile($"{i}|Brand{i}|Model{i}|Color{i}|{i + 1}|{i + 2}|{i + 3}")) == false);
            Assert.True(this.control.listaGoala() == true);
            this.control.saveData();
        }

        [Fact]
        public void modificare()
        {

        }



        //            OBJECT TEST

    }
}
