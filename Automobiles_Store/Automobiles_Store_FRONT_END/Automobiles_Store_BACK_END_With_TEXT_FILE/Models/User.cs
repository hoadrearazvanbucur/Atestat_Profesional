using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE.Models
{
    public class User : IComparable<User>
    {
        private int id, admin;
        private string name, password;

        public User(string data)
        {
            string[] dataSplit = data.Split('|');
            this.id = int.Parse(dataSplit[0]);
            this.admin = int.Parse(dataSplit[1]);
            this.name = dataSplit[2];
            this.password = dataSplit[3];
        }

        public override string ToString() => this.id + "|" + this.admin + "|" + this.name + "|" + this.password;
        public override bool Equals(object obj) => (obj as User).ToString() == this.ToString();
        public int CompareTo(User other)
        {
            if (other.Admin == this.admin && other.Name.Equals(this.name) == true && other.Password.Equals(this.password) == true)
                return 1;
            return 0;
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Admin
        {
            get => this.admin;
            set => this.admin = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public string Password
        {
            get => this.password;
            set => this.password = value;
        }
    }
}
