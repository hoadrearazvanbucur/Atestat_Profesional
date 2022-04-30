using Automobiles_Store_BACK_END_With_TEXT_FILE.Exceptions;
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
            this.loadData();
        }

        public void loadData()
        {
            this.clearData();
            StreamReader file = new StreamReader(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Automobiles_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                this.lista.adaugareSfarsit(new Automobile(line));
            file.Close();
        }

        public void saveData()
        {
            StreamWriter file = new StreamWriter(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Automobiles_File.txt");
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


        public Automobile obtineAutomobilDupaId(int id)
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
                throw new Automobile_Exception("Nu exista un automobil cu id-ul acesta");
        }

        public int obtineIdDupaAutomobil(Automobile automobile)
        {
            for (int i = 0; i < this.dimensiune(); i++)
                if (this.obtine(i).Data.CompareTo(automobile) == 0)
                    return this.obtine(i).Data.Id;
            throw new Automobile_Exception("Acest automobil nu exista");
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
                throw new Automobile_Exception("Acest id nu exista");
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


        public void adaugareSfarsit(Automobile automobile)
        {
            if (this.exista(automobile) == false)
                this.lista.adaugareSfarsit(automobile);
            else
                throw new Automobile_Exception("Acest automobil exista deja");
        }

        public void adaugareInceput(Automobile automobile)
        {
            if (this.exista(automobile) == false)
                this.lista.adaugareInceput(automobile);
            else
                throw new Automobile_Exception("Acest automobil exista deja");
        }

        public void adaugarePozitie(Automobile automobile, int index)
        {
            if (this.exista(automobile) == false && index >= 0 && index <= this.dimensiune())
                this.lista.adaugarePozitie(automobile, index);
            else
                if (this.exista(automobile) == true)
                throw new Automobile_Exception("Acest automobil exista deja");
            else
                throw new Automobile_Exception("Nu putem adauga pe aceasta pozitie");
        }


        public void stergereData(Automobile automobile)
        {
            if (this.exista(automobile) == true)
                this.lista.stergereData(automobile);
            else
                throw new Automobile_Exception("Acest automobil exista deja");
        }

        public void stergerePozitie(int index)
        {
            if (index >= 0 && index < this.dimensiune())
                this.lista.stergerePozitie(index);
            else
                throw new Automobile_Exception("Nu putem sterge automobilul din aceasta pozitie");
        }


        public void modificareDupaAutomobil(Automobile inlocuit, Automobile inlocuire)
        {
            if (this.exista(inlocuit) == true)
            {
                this.lista.modificareData(inlocuit, inlocuire);
            }
            else
                throw new Automobile_Exception("Automobilul pe care doriti sa il modificati nu exista");
        }

        public void modificareDupaId(int id, Automobile inlocuire)
        {
            if (this.existaId(id) == true)
            {
                this.lista.modificarePozitie(this.pozitieId(id), inlocuire);
            }
            else
                throw new Automobile_Exception("Automobilul pe care doriti sa il modificati nu exista");
        }


        public Nod<Automobile> obtine(int index)
        {
            if (index >= 0 && index < this.dimensiune())
                return this.lista.obtine(index);
            throw new Automobile_Exception("Aceasta pozitie nu exista");
        }

        public int pozitieData(Automobile data)
        {
            if (this.exista(data) == true)
                return this.lista.pozitieData(data);
            else
                throw new Automobile_Exception("Acest automobil nu exista");
        }

        public bool exista(Automobile data) => this.lista.exista(data);


        public bool listaGoala() => this.lista.listaGoala();

        public int dimensiune() => this.lista.dimensiune();

        public void clearData() => this.lista.golireLista();
        


        public void sortare(Comparer<Automobile> comparer, int value) => this.lista.sortare(comparer, value);

        public string afisare() => this.lista.afisare();





        public ILista<Automobile> Lista
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
