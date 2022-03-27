using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class Menu1DAO
    {
        private static Menu1DAO instance;

        public static Menu1DAO Instance
        {
            get { if (instance == null) instance = new Menu1DAO(); return Menu1DAO.instance; }
            private set { Menu1DAO.instance = value; }
        }

        private Menu1DAO() { }

        public List<Menu1> GetListMenuByTable(int TF_ID)
        {
            List<Menu1> listMenu = new List<Menu1>();
            string query = "select c.F_Name, a.BI_Total, c.F_Price, c.F_Price*a.BI_Total as TotalPrice, c.F_Funds*a.BI_Total as TotalFunds from dbo.BillInfor as a, dbo.Bill as b, dbo.Food as c where a.BI_IDBill = b.B_ID and a.BI_IDFood = c.F_ID and b.B_Status = 0 and b.B_IDTable = " + TF_ID;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                Menu1 menu = new Menu1(item);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
