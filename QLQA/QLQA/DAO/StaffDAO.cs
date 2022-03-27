using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class StaffDAO
    {
        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get { if (instance == null) instance = new StaffDAO(); return StaffDAO.instance; }
            private set { StaffDAO.instance = value; }
        }

        private StaffDAO() { }

        public List<Staff> GetListStaff()
        {
            List<Staff> list = new List<Staff>();
            string query = "select * from dbo.Staff";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Staff staff = new Staff(item);
                list.Add(staff);
            }
            return list;
        }

        public bool InsertStaff(string S_Name, string S_PhoneNumber, string S_IdentityCard, int S_Salary)
        {
            string query = string.Format("insert dbo.Staff ( S_Name, S_PhoneNumber, S_IdentityCard, S_Salary ) values ( N'{0}' , N'{1}', N'{2}', {3} )", S_Name, S_PhoneNumber, S_IdentityCard, S_Salary);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateStaff(int S_ID, string S_Name, string S_PhoneNumber, string S_IdentityCard, int S_Salary)
        {
            string query = string.Format("update dbo.Staff set S_Name = N'{0}', S_PhoneNumber = N'{1}', S_IdentityCard = N'{2}', S_Salary = {3} where S_ID = {4} ", S_Name, S_PhoneNumber, S_IdentityCard, S_Salary, S_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteStaff(int S_ID)
        {
            string query = string.Format("delete dbo.Staff where S_ID = {0} ", S_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
