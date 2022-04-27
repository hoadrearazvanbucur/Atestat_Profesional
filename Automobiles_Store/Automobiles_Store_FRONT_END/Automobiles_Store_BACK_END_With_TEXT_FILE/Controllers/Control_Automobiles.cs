using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;
using GENERIC_COLLECTIONS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers
{
    public class Control_Automobiles
    {
        private ILista<Automobile> lista;
        private string dataBase;

        public Control_Automobiles(string dataBase)
        {
            this.lista = new Lista<Automobile>();
            this.dataBase = dataBase;
        }

        public void load()
        {
            this.clear();
            StreamReader file = new StreamReader(this.path()+ @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Automobiles_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                lista.adaugareSfarsit(new Automobile(line));
            file.Close();
        }
        public void save()
        {
            StreamWriter file = new StreamWriter(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Automobiles_File.txt");
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
            this.lista.adaugareSfarsit(new Automobile(data));
        }
        public void removal(Automobile automobile)
        {
            this.lista.stergereData(automobile);
        }

        public void changeId(int id, int newId)
        {
            this.lista.obtine(this.positionId(id)).Data.Id = newId;
        }
        public void changeKm(int id, int newKm)
        {
            this.lista.obtine(this.positionId(id)).Data.Km = newKm;
        }
        public void changeAmount(int id, int newAmount)
        {
            this.lista.obtine(this.positionId(id)).Data.Amount = newAmount;
        }
        public void changePrice(int id, double newPrice)
        {
            this.lista.obtine(this.positionId(id)).Data.Price = newPrice;
        }
        public void changeBrand(int id, string newBrand)
        {
            this.lista.obtine(this.positionId(id)).Data.Brand = newBrand;
        }
        public void changeModel(int id, string newModel)
        {
            this.lista.obtine(this.positionId(id)).Data.Model = newModel;
        }
        public void changeColor(int id, string newColor)
        {
            this.lista.obtine(this.positionId(id)).Data.Color = newColor;
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

        public ILista<Automobile> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }
        public bool exist_Test(string text)
        {
            string[] textSplit = text.Split('|');
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Id == int.Parse(textSplit[0]) && this.lista.obtine(i).Data.Km == int.Parse(textSplit[4]) && this.lista.obtine(i).Data.Amount == int.Parse(textSplit[6]) && this.lista.obtine(i).Data.Price == double.Parse(textSplit[5]) && this.lista.obtine(i).Data.Brand == textSplit[1] && this.lista.obtine(i).Data.Model == textSplit[2] && this.lista.obtine(i).Data.Color == textSplit[3])
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
