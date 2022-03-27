using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class Category
    {
        public Category (int cF_ID, string cF_Name)
        {
            this.CF_ID = cF_ID;
            this.CF_Name = cF_Name;
        }

        public Category(DataRow row)
        {
            this.CF_ID = (int)row["cF_ID"];
            this.CF_Name = row["cF_Name"].ToString();
        }

        /*
        CF_ID int identity primary key,
	    CF_Name nvarchar (100) not null default N'Chưa có tên' 
        */
        private int cF_ID;
        private string cF_Name;

        public int CF_ID
        {
            get { return cF_ID; }
            set { cF_ID = value; }
        }

        public string CF_Name
        {
            get { return cF_Name; }
            set { cF_Name = value; }
        }
    }
}
