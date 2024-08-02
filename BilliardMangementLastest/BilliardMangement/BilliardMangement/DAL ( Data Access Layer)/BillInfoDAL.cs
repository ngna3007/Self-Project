using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DAL___Data_Access_Layer_
{
    public class BillInfoDAL : BaseQueryDAL
    {
        private static BillInfoDAL instance;

        public static BillInfoDAL Instance
        {
            get { if (instance == null) instance = new BillInfoDAL(); return instance; }
            private set { BillInfoDAL.instance = value; }
        }
        private BillInfoDAL() { }

        public List<BillInfo> GetListBillInfo(string query = "USP_GetListBillInfo @idBill")
        {
            return ExecuteLoadList(query, item => new BillInfo(item));
        }
        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBillInfo @idBill , @idFood , @count ", new object[] { idBill, idFood, count });
        }

        public override List<T> LoadList<T>(string query)
        {
            return instance.LoadList<T>(query);
        }
    }
}
