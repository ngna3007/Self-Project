using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DAL___Data_Access_Layer_
{
    public class MenuDAL : BaseQueryDAL
    {
        private static MenuDAL instance;

        public static MenuDAL Instance
        {
            get { if (instance == null) instance = new MenuDAL(); return instance; }
            private set { MenuDAL.instance = value; }
        }

        private MenuDAL() { }

        public List<Menu> LoadMenuList(string id)
        {
            string query = "EXEC USP_GetListMenuByTable @idTable = " + id;
            return ExecuteLoadList(query, item => new Menu(item));
        }

        public List<Time> LoadTimeList(string id)
        {
            string query = "EXEC USP_GetPlaytimeByTable @idTable = " + id;
            return ExecuteLoadList(query, item => new Time(item));
        }

        public override List<T> LoadList<T>(string query)
        {
            return instance.LoadList<T>(query);
        }
    }
}
