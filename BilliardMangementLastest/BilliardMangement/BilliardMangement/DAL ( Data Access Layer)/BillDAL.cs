using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DAL___Data_Access_Layer_
{
    public class BillDAL
    {
        private static BillDAL instance;

        public static BillDAL Instance 
        { 
            get { if (instance == null) instance = new BillDAL(); return instance; }
            private set { BillDAL.instance = value; }
        }

        private BillDAL() { }

        // Success: bill ID
        // Fail: -1
        public int GetUncheckBillIDByTableID(int id) 
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Bill WHERE idTable = " + id + " AND status = 0");

            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }

        public void CheckOutFood(int id, int discount)
        {
            string query = "UPDATE Bill SET status = 1, " + "discount =" + discount + " WHERE id = " + id;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void CheckOutTime(int id)
        {
            string query = "UPDATE BilliardTable SET starttime = NULL, endtime = NULL ,playtime = NULL WHERE id = " + id ;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void InsertBill(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] {id});
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM Bill");
            }
            catch
            {
                return 1;
            }
        }
    }
}
