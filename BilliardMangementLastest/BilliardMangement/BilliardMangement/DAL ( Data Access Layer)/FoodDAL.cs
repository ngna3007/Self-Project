using BilliardMangement.DTO____Data_Transfer_Object_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DAL___Data_Access_Layer_
{
    public class FoodDAL : BaseQueryDAL
    {

        private static FoodDAL instance;

        public static FoodDAL Instance
        {
            get { if (instance == null) instance = new FoodDAL(); return FoodDAL.instance; }
            private set { FoodDAL.instance = value; }
        }

        private FoodDAL() { }

        public List<Food> GetFoodByCategoryID(string id)
        {
            string query = "EXEC USP_GetFoodByCategoryID @idCategory = " + id;
            return ExecuteLoadList(query, item => new Food(item));
        }

        public override List<T> LoadList<T>(string query)
        {
            return instance.LoadList<T>(query);
        }
    }
}

