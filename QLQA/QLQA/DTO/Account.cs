using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLQA.DTO
{
    public class Account
    {
        public Account (string userName, string displayName, int idStaff, int type, string passWord = null)
        {
            this.UserName = userName;
            this.DisplayName = displayName;
            this.A_IDStaff = a_IDStaff;
            this.A_Type = a_Type;
            this.PassWord = passWord;
        }

        public Account (DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.DisplayName = row["displayName"].ToString();
            this.A_IDStaff = (int)row["a_IDStaff"];
            this.A_Type = (int)row["a_Type"];
            this.PassWord = row["passWord"].ToString();

        }

        private string userName;
        private string displayName;
        private string passWord;
        private int a_IDStaff;
        private int a_Type;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public string DisplayName
        {
            get { return displayName; }
            set { displayName = value; }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        public int A_IDStaff
        {
            get { return a_IDStaff; }
            set { a_IDStaff = value; }
        }

        public int A_Type
        {
            get { return a_Type; }
            set { a_Type = value; }
        }
    }
}
