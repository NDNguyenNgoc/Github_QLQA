using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class BillInfo
    {
        public BillInfo(int bI_ID, int bI_IDBill, int bI_IDFood, int bI_Total)
        {
            this.BI_ID = bI_ID;
            this.BI_IDBill = bI_IDBill;
            this.BI_IDFood = bI_IDFood;
            this.BI_Total = bI_Total;
        }

        public BillInfo(DataRow row)
        {
            this.BI_ID = (int)row["bI_ID"];
            this.BI_IDBill = (int)row["bI_IDBill"];
            this.BI_IDFood = (int)row["bI_IDFood"];
            this.BI_Total = (int)row["bI_Total"];
        }

        /*BI-ID, BI_IDBill, BI_IDFood, BI_Total*/
        private int bI_ID;
        private int bI_IDBill;
        private int bI_IDFood;
        private int bI_Total;

        public int BI_ID
        {
            get { return bI_ID; }
            set { bI_ID = value; }
        }

        public int BI_IDBill
        {
            get { return bI_IDBill; }
            set { bI_IDBill = value; }
        }

        public int BI_IDFood
        {
            get { return bI_IDFood; }
            set { bI_IDFood = value; }
        }

        public int BI_Total
        {
            get { return bI_Total; }
            set { bI_Total = value; }
        }
    }
}
