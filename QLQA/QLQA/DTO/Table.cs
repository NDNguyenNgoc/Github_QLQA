using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class Table
    {
        public Table (int tF_ID, string tF_Name, string tF_Status, int b_IDStaff)
        {
            this.TF_ID = tF_ID;
            this.TF_Name = tF_Name;
            this.TF_Status = tF_Status;
            //this.B_IDStaff = b_IDStaff;
        }

        public Table(DataRow row)
        {
            this.TF_ID = (int)row["tF_ID"];
            this.TF_Name = row["tF_Name"].ToString();
            this.TF_Status = row["tF_Status"].ToString();
            //this.B_IDStaff = (int)row["b_IDStaff"];
        }

        /*
        TF_ID int identity primary key,
	    TF_Name nvarchar (100) not null default N'Chưa có tên',
	    TF_Status nvarchar (100) not null default N'Trống' 
        */
        private int tF_ID;
        private string tF_Name;
        private string tF_Status;
        //private int b_IDStaff;

        public int TF_ID
        {
            get { return tF_ID; }
            set { tF_ID = value; }
        }

        public string TF_Name
        {
            get { return tF_Name; }
            set { tF_Name = value; }
        }

        public string TF_Status
        {
            get { return tF_Status; }
            set { tF_Status = value; }
        }

        //public int B_IDStaff
        //{
        //    get { return b_IDStaff; }
        //    set { b_IDStaff = value; }
        //}
    }
}
