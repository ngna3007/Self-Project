using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DTO____Data_Transfer_Object_
{
    public class Food
    {
        public Food(int id, string name, float price, int categoryID)
        {
            ID = id;
            Name = name;
            Price = price;
            CategoryID = categoryID;
        }

        public Food(DataRow row)
        {
            ID = (int)row["ID"];
            Name = row["Name"].ToString();
            CategoryID = (int)row["idCategory"];
            Price = (float)Convert.ToDouble(row["price"].ToString());
        }


        private float price;
        private int categoryID;
        private string name;
        private int iD;
        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public float Price { get => price; set => price = value; }
    }
}
