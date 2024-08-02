using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BilliardMangement.DTO____Data_Transfer_Object_
{
    public class Bill
    {
        public Bill(int id, DateTime? dateCheckin, DateTime? dateCheckout, int status, int discount = 0) 
        {
            ID = id;
            dateCheckIn = dateCheckin;
            dateCheckOut = dateCheckout;
            this.status = status;
            Discount = discount;

        }

        public Bill(DataRow row)
        {
            ID = (int)row["id"];
            dateCheckIn = (DateTime?)row["dateCheckin"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
            dateCheckOut = (DateTime?)dateCheckOutTemp;

            status = (int)row["status"];
            Discount = (int)row["discount"];
        }
        private int discount;
        private int status;

        private DateTime? dateCheckOut;

        private DateTime? dateCheckIn;

        private int iD;
        public int ID { get => iD; set => iD = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
