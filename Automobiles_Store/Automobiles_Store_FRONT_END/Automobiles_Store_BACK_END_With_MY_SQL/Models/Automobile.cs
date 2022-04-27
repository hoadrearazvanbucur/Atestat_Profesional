using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_MY_SQL.Models
{
    public class Automobile : IComparable<Automobile>
    {
        private int id, km, amount;
        private double price;
        private string brand, model, color;

        public Automobile(string data)
        {
            string[] dataSplit = data.Split('|');
            this.id = int.Parse(dataSplit[0]);
            this.brand = dataSplit[1];
            this.model = dataSplit[2];
            this.color = dataSplit[3];
            this.km = int.Parse(dataSplit[4]);
            this.price = double.Parse(dataSplit[5]);
            this.amount = int.Parse(dataSplit[6]);
        }

        public override string ToString() => this.id + "|" + this.brand + "|" + this.model + "|" + this.color + "|" + this.km + "|" + this.price + "|" + this.amount;
        public override bool Equals(object obj) => (obj as Automobile).ToString() == this.ToString();
        public int CompareTo(Automobile other)
        {
            if (other.Brand.Equals(this.brand) == true && other.Model.Equals(this.model) == true && other.Color.Equals(this.color) == true && other.Km == this.km && other.Price == this.price && other.Amount == this.amount)
                return 1;
            return 0;
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public string Brand
        {
            get => this.brand;
            set => this.brand = value;
        }
        public string Model
        {
            get => this.model;
            set => this.model = value;
        }
        public string Color
        {
            get => this.color;
            set => this.color = value;
        }
        public int Km
        {
            get => this.km;
            set => this.km = value;
        }
        public int Amount
        {
            get => this.amount;
            set => this.amount = value;
        }
        public double Price
        {
            get => this.price;
            set => this.price = value;
        }
    }
}
