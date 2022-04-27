using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Automobiles_Store_BACK_END_With_TEXT_FILE.Models;
using GENERIC_COLLECTIONS;

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

        public void load()
        {
            this.clear();
            StreamReader file = new StreamReader(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Users_File.txt");
            string line = "";
            while ((line = file.ReadLine()) != null)
                lista.adaugareSfarsit(new User(line));
            file.Close();
        }
        public void save()
        {
            StreamWriter file = new StreamWriter(this.path() + @"\Automobiles_Store_BACK_END_With_TEXT_FILE\bin\Debug\netstandard2.0\1_RESORCES\" + this.dataBase + @"\Users_File.txt");
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
            this.lista.adaugareSfarsit(new User(data));
        }
        public void removal(User user)
        {
            this.lista.stergereData(user);
        }

        public void changeId(int id, int newId)
        {
            this.lista.obtine(this.positionId(id)).Data.Id = newId;
        }
        public void changeAdmin(int id, int newAdmin)
        {
            this.lista.obtine(this.positionId(id)).Data.Admin = newAdmin;
        }
        public void changeName(int id, string newName)
        {
            this.lista.obtine(this.positionId(id)).Data.Name = newName;
        }
        public void changePassword(int id, string newPassword)
        {
            this.lista.obtine(this.positionId(id)).Data.Password = newPassword;
        }

        public void makeRemoveAdmin(int id, int adminIndex)
        {
            if (adminIndex == 1)
                this.lista.obtine(this.positionId(id)).Data.Admin = 0;
            else
                this.lista.obtine(this.positionId(id)).Data.Admin = 1;
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

        public ILista<User> Lista
        {
            get => this.lista;
            set => this.lista = value;
        }
        public bool exist_Test(string text)
        {
            string[] textSplit = text.Split('|');
            for (int i = 0; i < this.lista.dimensiune(); i++)
                if (this.lista.obtine(i).Data.Id == int.Parse(textSplit[0]) && this.lista.obtine(i).Data.Admin == int.Parse(textSplit[1]) && this.lista.obtine(i).Data.Name == textSplit[2] && this.lista.obtine(i).Data.Password == textSplit[3])
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
