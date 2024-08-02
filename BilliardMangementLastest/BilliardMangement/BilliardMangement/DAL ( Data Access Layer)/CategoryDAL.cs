using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DAL___Data_Access_Layer_
{
    public class CategoryDAL : BaseQueryDAL
    {
        private static CategoryDAL instance;

        public static CategoryDAL Instance 
        { 
            get { if (instance == null) instance = new CategoryDAL(); return CategoryDAL.instance; }
            private set { CategoryDAL.instance = value; }
        }

        private CategoryDAL() { }

        public List<Category> GetListCategory(string query = "USP_GetListCategory")
        {
            return ExecuteLoadList(query, item => new Category(item));
        }

        public override List<T> LoadList<T>(string query)
        {
            return instance.LoadList<T>(query);
        }
    }
}
