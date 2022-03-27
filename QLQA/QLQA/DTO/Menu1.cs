using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class Menu1
    {
        public Menu1 (string f_Name, int bI_Total, float f_Price, float totalFunds, float totalPrice = 0)
        {
            this.F_Name = f_Name;
            this.BI_Total = bI_Total;
            this.F_Price = f_Price;
            this.TotalPrice = totalPrice;
            this.TotalFunds = totalFunds;
        }

        public Menu1 (DataRow row)
        {
            this.F_Name = row["f_Name"].ToString();
            this.BI_Total = (int)row["bI_Total"];
            this.F_Price = (float)Convert.ToDouble(row["f_Price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
            this.TotalFunds = (float)Convert.ToDouble(row["totalFunds"].ToString());
        }

        private string f_Name;
        private int bI_Total;
        private float f_Price;
        private float totalPrice;
        private float totalFunds;

        public string F_Name
        {
            get { return f_Name; }
            set { f_Name = value; }
        }

        public int BI_Total
        {
            get { return bI_Total; }
            set { bI_Total = value; }
        }

        public float F_Price
        {
            get { return f_Price; }
            set { f_Price = value; }
        }

        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        public float TotalFunds
        {
            get { return totalFunds; }
            set { totalFunds = value; }
        }
    }
}
