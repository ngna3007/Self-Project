using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DTO____Data_Transfer_Object_
{
    public class Menu
    {
        public Menu(string foodName, int count, float price, float totalPrice)
        {
            FoodName = foodName;
            Count = count; 
            Price = price;
            TotalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            FoodName = row["Name"].ToString();
            Count = (int)row["count"];
            Price = (float)Convert.ToDouble(row["price"].ToString());
            TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }


        private float totalPrice;
        private float price;
        private int count;
        private string foodName;
        

        public string FoodName { get => foodName; set => foodName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
        
    }

    public class Time
    {
        public Time(string playtime, string starttime, string endtime, string totalPrice)
        {
            playTime = playtime;
            TotalTimePrice = totalPrice;
            StartTime = starttime;
            EndTime = endtime;
        }

        public Time(DataRow row)
        {
            PlayTime = row["playtime"].ToString();
            StartTime = row["starttime"].ToString();
            EndTime = row["endtime"].ToString();
            TotalTimePrice = row["totalPrice"].ToString();
        }

        private string playTime;
        private string startTime;
        private string endTime;
        private string totalTimePrice;


        public string PlayTime { get => playTime; set => playTime = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string EndTime { get => endTime; set => endTime = value; }

        public string TotalTimePrice { get => totalTimePrice; set => totalTimePrice = value; }
    }
}
