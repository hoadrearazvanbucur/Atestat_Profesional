using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;
using GENERIC_COLLECTIONS;

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
        }
        public void load()
        {
            this.clear();
            StreamReader file = new StreamReader(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Orders_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                lista.adaugareSfarsit(new Order(line));
            file.Close();
        }
        public void save()
        {
            StreamWriter file = new StreamWriter(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Orders_File.txt");
            for (int i = 0; i < this.lista.dimensiune(); i++)
                file.WriteLine(lista.obtine(i).Data.ToString());
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
        public void clear()
        {
            if (this.lista.listaGoala() != true)
                for (int i = this.lista.dimensiune() - 1; i >= 0; i--)
                    this.lista.stergereData(this.lista.obtine(i).Data);
        }

        public string show()
        {
            string text = "";
            for (int i = 0; i < this.lista.dimensiune(); i++)
                text += this.lista.obtine(i).Data.ToString() + "\n";
            return text;
        }
        public void adding(string data)
        {
            this.lista.adaugareSfarsit(new Order(data));
        }
        public void removal(Order order)
        {
            this.lista.stergereData(order);
        }

        public void changeId(int id, int newId)
        {
            this.lista.obtine(this.positionId(id)).Data.Id = newId;
        }
        public void changeId_user(int id, int newId_user)
        {
            this.lista.obtine(this.positionId(id)).Data.Id_user = newId_user;
        }
        public void changeOrderSize(int id, int newOrderSize)
        {
            this.lista.obtine(this.positionId(id)).Data.OrderSize = newOrderSize;
        }
        public void changeAutomobiles_ID(int id, int[] newAutomobiles_ID)
        {
            this.lista.obtine(this.positionId(id)).Data.Automobile_ID = newAutomobiles_ID;
        }
        public void changeAmounts(int id, int[] newAmounts)
        {
            this.lista.obtine(this.positionId(id)).Data.Amounts = newAmounts;
        }

        public ILista<Order> getOrderList(int id_user)
        {
            ILista<Order> nou = new Lista<Order>();
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Id_user == id_user)
                    nou.adaugareSfarsit(this.lista.obtine(i).Data);
            return nou;
        }
        public double getOrderPrice(Order order, Control_Automobiles control)
        {
            double price = 0;
            for (int i = 0; i < order.OrderSize; i++)
                price += control.Lista.obtine(control.positionId(order.Automobile_ID[i])).Data.Price * order.Amounts[i];
            return price;
        }
        public bool canBeBought(Order order, Control_Automobiles control)
        {
            for (int i = 0; i < order.OrderSize; i++)
                if (control.Lista.obtine(control.positionId(order.Automobile_ID[i])).Data.Amount < order.Amounts[i])
                    return false;
            return true;
        }

        public int positionId(int id)
        {
            int k = 0;
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Id == id)
                    return k;
                else
                    k++;
            return -1;
        }
        public int generationId()
        {
            if (this.lista.listaGoala() != true)
                return this.lista.obtine(this.lista.dimensiune() - 1).Data.Id + 1;
            else
                return 1;
        }

        public ILista<Order> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }
        public bool exist_Test(string data)
        {
            string[] dataSplit = data.Split('|');
            string[] automobiles_IDSplit = dataSplit[3].Split(',');
            string[] amountsSplit = dataSplit[4].Split(',');
            string text = dataSplit[0] + "|" + dataSplit[1] + "|" + dataSplit[2] + "|";
            for (int j = 0; j < int.Parse(dataSplit[2]) - 1; j++)
                text += automobiles_IDSplit[j] + ",";
            text += automobiles_IDSplit[int.Parse(dataSplit[2]) - 1] + "|";
            for (int j = 0; j < int.Parse(dataSplit[2]) - 1; j++)
                text += amountsSplit[j] + ",";
            text += amountsSplit[int.Parse(dataSplit[2]) - 1];
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.ToString() == text)
                    return true;
            return false;
        }
        public string DataBase
        {
            get => this.dataBase;
            set => this.dataBase = value;
        }
    }
}
