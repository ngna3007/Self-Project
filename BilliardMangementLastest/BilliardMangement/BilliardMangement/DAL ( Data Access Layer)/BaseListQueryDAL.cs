using System;
using System.Collections.Generic;
using System.Data;

namespace BilliardMangement.DAL___Data_Access_Layer_
{
    public abstract class BaseQueryDAL
    {
        public abstract List<T> LoadList<T>(string query);

        protected List<T> ExecuteLoadList<T>(string query, Func<DataRow, T> createItem)
        {
            List<T> list = new List<T>();
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                T obj = createItem(item);
                list.Add(obj);
            }

            return list;
        }
    }
}
