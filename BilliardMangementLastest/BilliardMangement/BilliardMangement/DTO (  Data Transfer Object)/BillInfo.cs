using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DTO____Data_Transfer_Object_
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int foodID, int count) 
        {
            BillID = billID;
            FoodID = foodID;
            Count = count;
            ID = id;
        }
        public BillInfo(DataRow row) 
        {
            ID = (int)row["id"];
            BillID = (int)row["idbill"];
            FoodID = (int)row["idfood"];
            Count = (int)row["count"];
        }

        private int count;
        private int foodID;
        private int billID;
        private int iD;
        public int ID { get => iD; set => iD = value; }
        public int BillID { get => billID; set => billID = value; }
        public int FoodID { get => foodID; set => foodID = value; }
        public int Count { get => count; set => count = value; }
    }
}
