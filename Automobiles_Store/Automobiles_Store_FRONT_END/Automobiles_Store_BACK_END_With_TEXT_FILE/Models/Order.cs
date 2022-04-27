using System;
using System.Collections.Generic;
using System.Text;

namespace Automobiles_Store_BACK_END_With_TEXT_FILE.Models
{
    public class Order : IComparable<Order>
    {
        private int id, id_user, orderSize;
        private int[] automobiles_ID;
        private int[] amounts;

        public Order(string data)
        {
            string[] dataSplit = data.Split('|');
            string[] automobiles_IDSplit = dataSplit[3].Split(',');
            string[] amountsSplit = dataSplit[4].Split(',');
            this.id = int.Parse(dataSplit[0]);
            this.id_user = int.Parse(dataSplit[1]);
            this.orderSize = int.Parse(dataSplit[2]);
            this.automobiles_ID = new int[this.orderSize];
            this.amounts = new int[this.orderSize];
            for (int i = 0; i < this.orderSize; i++)
            {
                this.automobiles_ID[i] = int.Parse(automobiles_IDSplit[i]);
                this.amounts[i] = int.Parse(amountsSplit[i]);
            }
        }

        public override string ToString()
        {
            string text = this.id + "|" + this.id_user + "|" + this.orderSize + "|";
            for (int i = 0; i < this.orderSize - 1; i++)
                text += this.automobiles_ID[i] + ",";
            text += this.automobiles_ID[this.orderSize - 1] + "|";
            for (int i = 0; i < this.orderSize - 1; i++)
                text += this.amounts[i] + ",";
            text += this.amounts[this.orderSize - 1];
            return text;
        }
        public string ToStringWithNoId(Order order)
        {
            string text = this.id_user + "|" + this.orderSize + "|";
            for (int i = 0; i < this.orderSize - 1; i++)
                text += this.automobiles_ID[i] + ",";
            text += this.automobiles_ID[this.orderSize - 1] + "|";
            for (int i = 0; i < this.orderSize - 1; i++)
                text += this.amounts[i] + ",";
            text += this.amounts[this.orderSize - 1];
            return text;
        }
        public override bool Equals(object obj) => (obj as Order).ToString() == this.ToString();
        public int CompareTo(Order other)
        {
            if (this.ToStringWithNoId(other).Equals(this.ToStringWithNoId(this)) == true)
                return 1;
            return 0;
        }

        public void addAutomobile(int dataAutomobile_ID, int dataAmount)
        {
            int[] newAutomobiles_ID = new int[++this.orderSize];
            int[] newAmounts = new int[this.orderSize];
            for (int i = 0; i < this.orderSize-1; i++)
            {
                newAutomobiles_ID[i] = this.automobiles_ID[i];
                newAmounts[i] = this.amounts[i];
            }
            newAutomobiles_ID[orderSize - 1] = dataAutomobile_ID;
            newAmounts[orderSize - 1] = dataAmount;
            this.automobiles_ID = newAutomobiles_ID;
            this.amounts = newAmounts;
        }
        public void delAutomobile(int dataAutomobile_ID)
        {
            for (int i = 0; i < orderSize; i++)
                if (this.automobiles_ID[i] == dataAutomobile_ID)
                {
                    for (int j = i; j < this.orderSize-1; j++)
                    {
                        this.automobiles_ID[j] = this.automobiles_ID[j + 1];
                        this.amounts[j] = this.amounts[j + 1];
                    }
                    this.automobiles_ID[this.orderSize - 1] = 0;
                    this.amounts[this.orderSize - 1] = 0;
                    break;
                }
            int[] newAutomobiles_ID = new int[--this.orderSize];
            int[] newAmounts = new int[this.orderSize];
            for (int i = 0; i < this.orderSize; i++)
            {
                newAutomobiles_ID[i] = this.automobiles_ID[i];
                newAmounts[i] = this.amounts[i];
            }
            this.automobiles_ID = newAutomobiles_ID;
            this.amounts = newAmounts;
        }
        public bool findAutomobile(int dataAutomobile_ID)
        {
            for (int i = 0; i < this.orderSize; i++)
                if (this.automobiles_ID[i] == dataAutomobile_ID)
                    return true;
            return false;
        }

        public int Id
        {
            get => this.id;
            set => this.id = value;
        }
        public int Id_user
        {
            get => this.id_user;
            set => this.id_user = value;
        }
        public int OrderSize
        {
            get => this.orderSize;
            set => this.orderSize = value;
        }
        public int[] Automobile_ID
        {
            get => this.automobiles_ID;
            set => this.automobiles_ID = value;
        }
        public int[] Amounts
        {
            get => this.amounts;
            set => this.amounts = value;
        }
    }
}
