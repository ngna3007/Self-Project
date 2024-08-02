using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DAL___Data_Access_Layer_
{
    public class TableDAL : BaseQueryDAL
    {
        private static TableDAL instance;

        public static TableDAL Instance
        {
            get { if (instance == null) instance = new TableDAL(); return TableDAL.instance; }
            private set { TableDAL.instance = value; }
        }

        public static int TableWidth = 120;
        public static int TableHeight = 120;

        private TableDAL() { }

        public List<Table> LoadTableList()
        {
            string query = "EXEC USP_GetTableList";
            return ExecuteLoadList<Table>(query, item => new Table(item));
        }

        public override List<T> LoadList<T>(string query)
        {
            return instance.LoadList<T>(query);
        }
    }
}
