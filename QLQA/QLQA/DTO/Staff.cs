using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class Staff
    {
        public Staff (int s_ID, string s_Name, string s_PhoneNumber, string s_IdentityCard, int s_Salary)
        {
            this.S_ID = s_ID;
            this.S_Name = s_Name;
            this.S_PhoneNumber = s_PhoneNumber;
            this.S_IdentityCard = s_IdentityCard;
            this.S_Salary = s_Salary;
        }

        public Staff(DataRow row)
        {
            this.S_ID = (int)row["s_ID"];
            this.S_Name = row["s_Name"].ToString();
            this.S_PhoneNumber = row["s_PhoneNumber"].ToString();
            this.S_IdentityCard = row["s_IdentityCard"].ToString();
            this.S_Salary = (int)row["s_Salary"];
        }

        /*
        S_ID int identity primary key,
	    S_Name nvarchar(100) not null,
	    S_PhoneNumber varchar(10) not null,
	    S_IdentityCard varchar(10) not null,
	    S_Salary int null
        */
        private int s_ID;
        private string s_Name;
        private string s_PhoneNumber;
        private string s_IdentityCard;
        private int s_Salary;

        public int S_ID
        {
            get { return s_ID; }
            set { s_ID = value; }
        }

        public string S_Name
        {
            get { return s_Name; }
            set { s_Name = value; }
        }

        public string S_PhoneNumber
        {
            get { return s_PhoneNumber; }
            set { s_PhoneNumber = value; }
        }

        public string S_IdentityCard
        {
            get { return s_IdentityCard; }
            set { s_IdentityCard = value; }
        }

        public int S_Salary
        {
            get { return s_Salary; }
            set { s_Salary = value; }
        }
    }
}
