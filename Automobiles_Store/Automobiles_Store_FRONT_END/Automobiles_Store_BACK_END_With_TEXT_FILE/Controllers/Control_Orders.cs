using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;
using GENERIC_COLLECTIONS;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Exceptions;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers
{
    public class Control_Orders
    {
        private ILista<Order> lista;
        private string dataBase;

        public Control_Orders(string dataBase)
        {
            this.lista = new Lista<Order>();
            this.dataBase = dataBase;
            this.loadData();
        }

        public void loadData()
        {
            this.clearData();
            StreamReader file = new StreamReader(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Orders_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                this.lista.adaugareSfarsit(new Order(line));
            file.Close();
        }
        public void saveData()
        {
            StreamWriter file = new StreamWriter(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Orders_File.txt");
            for (int i = 0; i < this.dimensiune(); i++)
                file.WriteLine(this.obtine(i).Data.ToString());
            file.Close();
        }
        public string path()
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            string directoryPath = @"\Automobiles_Store\Automobiles_Store_FRONT_END";
            for (int i = projectPath.Length - 1; i >= directoryPath.Length - 1; i--)
            {
                int ok = 1, k = directoryPath.Length - 1;
                for (int j = i; j >= i - directoryPath.Length + 1; j--)
                    if (projectPath[j] != directoryPath[k--])
                        ok = 0;
                if (ok == 1)
                    return projectPath.Substring(0, i + 1);
            }
            return null;
        }





        public Order obtineComandaDupaId(int id)
        {
            if (this.existaId(id) == true)
            {
                int index = -1;
                for (int i = 0; i < this.dimensiune(); i++)
                    if (this.obtine(i).Data.Id == id)
                    {
                        index = i;
                        break;
                    }
                return this.obtine(index).Data;
            }
            else
                throw new Order_Exception("Nu exista o comanda cu id-ul acesta");
        }

        public int obtineIdDupaComanda(Order order)
        {
            for (int i = 0; i < this.dimensiune(); i++)
                if (this.obtine(i).Data.CompareTo(order) == 0)
                    return this.obtine(i).Data.Id;
            throw new Order_Exception("Aceasta comanda nu exista");
        }

        public int generareId()
        {
            if (this.listaGoala() == false)
                return maximId() + 1;
            else
                return 1;
        }

        public int maximId()
        {
            int maxim = int.MinValue;
            for (int i = 0; i < this.dimensiune(); i++)
                if (maxim < this.obtine(i).Data.Id)
                    maxim = this.obtine(i).Data.Id;
            if (maxim != int.MinValue)
                return maxim;
            else
                return 1;
        }


        public int pozitieId(int id)
        {
            int k = -1;
            for (int i = 0; i < this.dimensiune(); i++)
                if (this.obtine(i).Data.Id == id)
                {
                    k = i;
                    break;
                }
            if (k == -1)
                throw new Order_Exception("Acest id nu exista");
            else
                return k;
        }

        public bool existaId(int id)
        {
            for (int i = 0; i < this.dimensiune(); i++)
                if (this.obtine(i).Data.Id == id)
                    return true;
            return false;
        }


        public void adaugareSfarsit(Order order)
        {
            if (this.exista(order) == false)
                this.lista.adaugareSfarsit(order);
            else
                throw new Order_Exception("Aceasta comanda exista deja");
        }

        public void adaugareInceput(Order order)
        {
            if (this.exista(order) == false)
                this.lista.adaugareInceput(order);
            else
                throw new Order_Exception("Aceasta comanda exista deja");
        }

        public void adaugarePozitie(Order order, int index)
        {
            if (this.exista(order) == false && index >= 0 && index <= this.dimensiune())
                this.lista.adaugarePozitie(order, index);
            else
                if (this.exista(order) == true)
                throw new Order_Exception("Aceasta comanda exista deja");
            else
                throw new Order_Exception("Nu putem adauga pe aceasta pozitie");
        }


        public void stergereData(Order order)
        {
            if (this.exista(order) == true)
                this.lista.stergereData(order);
            else
                throw new Order_Exception("Aceasta comanda exista deja");
        }

        public void stergerePozitie(int index)
        {
            if (index >= 0 && index < this.dimensiune())
                this.lista.stergerePozitie(index);
            else
                throw new Order_Exception("Nu putem sterge comanda din aceasta pozitie");
        }


        public void modificareDupaComanda(Order inlocuit, Order inlocuire)
        {
            if (this.exista(inlocuit) == true)
            {
                this.lista.modificareData(inlocuit, inlocuire);
            }
            else
                throw new Order_Exception("Comanda pe care doriti sa o modificati nu exista");
        }

        public void modificareDupaId(int id, Order inlocuire)
        {
            if (this.existaId(id) == true)
            {
                this.lista.modificarePozitie(this.pozitieId(id), inlocuire);
            }
            else
                throw new Order_Exception("Comanda pe care doriti sa o modificati nu exista");
        }


        public Nod<Order> obtine(int index)
        {
            if (index >= 0 && index < this.dimensiune())
                return this.lista.obtine(index);
            throw new Order_Exception("Aceasta pozitie nu exista");
        }

        public int pozitieData(Order data)
        {
            if (this.exista(data) == true)
                return this.lista.pozitieData(data);
            else
                throw new Order_Exception("Aceasta comanda nu exista");
        }

        public bool exista(Order data) => this.lista.exista(data);


        public bool listaGoala() => this.lista.listaGoala();

        public int dimensiune() => this.lista.dimensiune();

        public void clearData() => this.lista.golireLista();
        


        public void sortare(Comparer<Order> comparer, int value) => this.lista.sortare(comparer, value);

        public string afisare() => this.lista.afisare();










        public ILista<Order> obtineListaClientului(int id_user)
        {
            ILista<Order> nou = new Lista<Order>();
            nou = null;
            for (int i = 0; i < this.dimensiune(); i++)
                if (this.obtine(i).Data.Id_user == id_user)
                    nou.adaugareSfarsit(this.obtine(i).Data);
            return nou;
        }
        public double obtinePretulComenzii(Order order, Control_Automobiles control)
        {
            double price = 0;
            for (int i = 0; i < order.OrderSize; i++)
                price += control.Lista.obtine(control.pozitieId(order.Automobile_ID[i])).Data.Price * order.Amounts[i];
            return price;
        }
        public bool poateFiCumparat(Order order, Control_Automobiles control)
        {
            for (int i = 0; i < order.OrderSize; i++)
                if (control.obtine(control.pozitieId(order.Automobile_ID[i])).Data.Amount < order.Amounts[i])
                    return false;
            return true;
        }


        public ILista<Order> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }

        public string DataBase
        {
            get => this.dataBase;
            set => this.dataBase = value;
        }
    }
}
