using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 120;
        public static int TableHeight = 120;

        private TableDAO() { }

        public void SwitchTable(int idTable1, int idTable2, int idStaff1, int idStaff2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTable @idTable1 , @idTable2 , @idStaff1 , @idStaff2 ", new object[] { idTable1, idTable2, idStaff1, idStaff2 });
        }

        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }
            return tableList;
        }

        public List<Table> GetListTable()
        {
            List<Table> list = new List<Table>();
            string query = "select * from dbo.TableFood";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }

        public bool InsertTable(string TF_Name)
        {
            string query = string.Format("insert dbo.TableFood ( TF_Name) values ( N'{0}')", TF_Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateTable(int TF_ID, string TF_Name, string TF_Status)
        {
            string query = string.Format("update dbo.TableFood set TF_Name = N'{0}', TF_Status = N'{1}' where TF_ID = {2}", TF_Name, TF_Status, TF_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteTable(int TF_ID)
        {
            BillInfoDAO.Instance.DeleteBillInfoByTableFoodID(TF_ID);
            BillDAO.Instance.DeleteBillByTableFoodID(TF_ID);
            string query = string.Format("delete dbo.TableFood where TF_ID = {0}", TF_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public int GetIDStaffByTable (int TF_ID)
        {
            string query = string.Format("select b.B_IDStaff from dbo.TableFood as a, dbo.Bill as b where a.TF_ID = {0} and a.TF_ID = b.B_IDTable and b.B_Status = 0", TF_ID);
            int staffID = DataProvider.Instance.ExecuteNonQuery(query);
            return staffID;
        }
    }
}
