using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class Bill
    {
        public Bill (int b_ID, DateTime? dateCheckIn, DateTime? dateCheckOut, int b_Status, int b_Discount)
        {
            this.B_ID = b_ID;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.B_Status = b_Status;
            this.B_Discount = b_Discount;
        }

        public Bill(DataRow row)
        {
            this.B_ID = (int)row["b_ID"];
            this.DateCheckIn = (DateTime?)row["dateCheckIn"];

            var dateCheckOutTemp = row["dateCheckOut"];
            if (dateCheckOutTemp.ToString() != "")
                this.DateCheckOut = (DateTime?)dateCheckOutTemp;

            this.B_Status = (int)row["b_Status"];

            if (row["b_Discount"].ToString() != "")
                this.B_Discount = (int)row["b_Discount"];
        }

        /*B_ID, DateCheckIn, DateCheckOut, B_Status, B_Discount*/
        private int b_ID;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int b_Status;
        private int b_Discount;

        public int B_ID
        {
            get { return b_ID; }
            set { b_ID = value; }
        }

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }

        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        public int B_Status
        {
            get { return b_Status; }
            set { b_Status = value; }
        }

        public int B_Discount
        {
            get { return b_Discount; }
            set { b_Discount = value; }
        }
    }
}
