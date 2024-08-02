using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DTO____Data_Transfer_Object_
{
    public class Category
    {
        public Category(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public Category(DataRow row)
        {
            ID = (int)row["ID"];
            Name = row["Name"].ToString();
        }

        private string name;
        private int iD;

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
    }
}
