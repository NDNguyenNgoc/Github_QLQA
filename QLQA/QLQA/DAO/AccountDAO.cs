using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool login (string UserName, string PassWord)
        {
            string query = "USP_Login @Username , @Password";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { UserName, PassWord });
            return result.Rows.Count > 0;
        }

        public bool updateAccount (string UserName , string DisplayName, string PassWord, string NewPass)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_UpdateAccount @userName , @displayName , @passWord , @newpassWord ", new object[] { UserName, DisplayName, PassWord, NewPass});
            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return DataProvider.Instance.ExecuteQuery("select UserName, DisplayName, A_IDStaff, A_Type from dbo.Account");
        }

        public Account GetAccountByUsername (string UserName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Account where UserName = N'" + UserName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool InsertAccount(string UserName, string DisplayName, int A_IDStaff, int Type)
        {
            string query = string.Format("insert dbo.Account (UserName, DisplayName, A_IDStaff, A_Type) values(N'{0}', N'{1}', {2}, {3} )", UserName, DisplayName, A_IDStaff, Type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateAccount (string UserName, string DisplayName, int A_IDStaff, int Type)
        {
            string query = string.Format("update dbo.Account set DisplayName = N'{0}', A_IDStaff = {1}, A_Type = {2} where UserName = N'{3}'", DisplayName, A_IDStaff, Type, UserName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteAccount(string UserName)
        {
            string query = string.Format("delete dbo.Account where UserName = N'{0}'", UserName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool ResetPass(string UserName)
        {
            string query = string.Format("update dbo.Account set PassWord = N'1' where UserName = N'{0}'", UserName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
