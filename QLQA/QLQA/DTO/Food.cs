using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class Food
    {
        public Food (int f_ID, string f_Name, int f_IDCategory, float f_Funds, float f_Price)
        {
            this.F_ID = f_ID;
            this.F_Name = f_Name;
            this.F_IDCategory = f_IDCategory;
            this.F_Funds = f_Funds;
            this.F_Price = f_Price;
        }

        public Food(DataRow row)
        {
            this.F_ID = (int)row["f_ID"];
            this.F_Name = row["f_Name"].ToString();
            this.F_IDCategory = (int)row["f_IDCategory"];
            this.F_Funds = (float)Convert.ToDouble(row["f_Funds"].ToString());
            this.F_Price = (float)Convert.ToDouble(row["f_Price"].ToString());
        }

        /*
        F_ID int identity primary key,
	    F_Name nvarchar (100) not null default N'Chưa có tên',
	    F_IDCategory int not null,
	    F_Funds Float not null,
	    F_Price Float not null*/
        private int f_ID;
        private string f_Name;
        private int f_IDCategory;
        private float f_Funds;
        private float f_Price;

        public int F_ID
        {
            get { return f_ID; }
            set { f_ID = value; }
        }

        public string F_Name
        {
            get { return f_Name; }
            set { f_Name = value; }
        }

        public int F_IDCategory
        {
            get { return f_IDCategory; }
            set { f_IDCategory = value; }
        }

        public float F_Funds
        {
            get { return f_Funds; }
            set { f_Funds = value; }
        }

        public float F_Price
        {
            get { return f_Price; }
            set { f_Price = value; }
        }
    }
}
