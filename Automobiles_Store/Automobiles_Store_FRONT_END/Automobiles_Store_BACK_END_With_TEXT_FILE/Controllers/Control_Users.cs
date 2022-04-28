using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;
using GENERIC_COLLECTIONS;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Exceptions;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE.Controllers
{
    public class Control_Users
    {
        private ILista<User> lista;
        private string dataBase;

        public Control_Users(string dataBase)
        {
            this.lista = new Lista<User>();
            this.dataBase = dataBase;
        }

        public void loadData()
        {
            this.clearData();
            StreamReader file = new StreamReader(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Users_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                this.lista.adaugareSfarsit(new User(line));
            file.Close();
        }
        public void saveData()
        {
            StreamWriter file = new StreamWriter(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Users_File.txt");
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



        public User obtineUserDupaId(int id)
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
                throw new User_Exception("Nu exista un user cu id-ul acesta");
        }
        public int obtineIdDupaUser(User user)
        {
            for (int i = 0; i < this.dimensiune(); i++)
                if (this.obtine(i).Data.CompareTo(user) == 0)
                    return this.obtine(i).Data.Id;
            throw new User_Exception("Acest user nu exista");
        }



        public int generationId()
        {
            if (this.listaGoala() == false)
                return this.obtine(this.dimensiune() - 1).Data.Id + 1;
            else
                return 1;
        }
        public int positionId(int id)
        {
            int k = -1;
            for (int i = 0; i < this.dimensiune(); i++)
                if (this.obtine(i).Data.Id == id)
                {
                    k = i;
                    break;
                }
            if (k == -1)
                throw new User_Exception("Acest id nu exista");
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


        public int getId(string name, string password)
        {
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Name == name && this.lista.obtine(i).Data.Password == password)
                    return this.lista.obtine(i).Data.Id;
            return -1;
        }
        public int getAdmin(string name, string password)
        {
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Name == name && this.lista.obtine(i).Data.Password == password)
                    return this.lista.obtine(i).Data.Admin;
            return -1;
        }
        public bool login_exist(string name, string password)
        {
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Name == name && this.lista.obtine(i).Data.Password == password)
                    return true;
            return false;
        }









        public void adaugareSfarsit(User user)
        {
            if (this.exista(user) == false)
                this.lista.adaugareSfarsit(user);
            else
                throw new User_Exception("Acest user exista deja");
        }
        public void adaugareInceput(User user)
        {
            if (this.exista(user) == false)
                this.lista.adaugareInceput(user);
            else
                throw new User_Exception("Acest automobil exista deja");
        }
        public void adaugarePozitie(User user, int index)
        {
            if (this.exista(user) == false && index >= 0 && index <= this.dimensiune())
                this.lista.adaugarePozitie(user, index);
            else
                if (this.exista(user) == true)
                throw new User_Exception("Acest user exista deja");
            else
                throw new User_Exception("Nu putem adauga pe aceasta pozitie");
        }
        public void stergereData(User user)
        {
            if (this.exista(user) == true)
                this.lista.stergereData(user);
            else
                throw new User_Exception("Acest user exista deja");
        }
        public void stergerePozitie(int index)
        {
            if (index >= 0 && index < this.dimensiune())
                this.lista.stergerePozitie(index);
            else
                throw new User_Exception("Nu putem sterge user-ul din aceasta pozitie");
        }
        public void modificareDupaUser(User inlocuit, User inlocuire)
        {
            if (this.exista(inlocuit) == true)
            {
                this.lista.modificareData(inlocuit, inlocuire);
            }
            else
                throw new User_Exception("User-ul pe care doriti sa il modificati nu exista");
        }
        public void modificareDupaId(int id, User inlocuire)
        {
            if (this.existaId(id) == true)
            {
                this.lista.modificarePozitie(this.positionId(id), inlocuire);
            }
            else
                throw new User_Exception("User-ul pe care doriti sa il modificati nu exista");
        }
        public Nod<User> obtine(int index)
        {
            if (index >= 0 && index < this.dimensiune())
                return this.lista.obtine(index);
            throw new User_Exception("Aceasta pozitie nu exista");
        }
        public int pozitieData(User data)
        {
            if (this.exista(data) == true)
                return this.lista.pozitieData(data);
            else
                throw new User_Exception("Acest automobil nu exista");
        }
        public bool exista(User data) => this.lista.exista(data);
        public bool listaGoala() => this.lista.listaGoala();
        public int dimensiune() => this.lista.dimensiune();
        public void clearData()
        {
            if (this.listaGoala() == false)
                this.lista.golireLista();
            else
                throw new User_Exception("Lista este deja goala");
        }
        public void sortare(Comparer<User> comparer, int value) => this.lista.sortare(comparer, value);
        public string afisare() => this.lista.afisare();


        public ILista<User> Lista
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
