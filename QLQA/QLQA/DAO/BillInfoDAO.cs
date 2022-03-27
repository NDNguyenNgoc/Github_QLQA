using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;
        public static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return BillInfoDAO.instance; }
            private set { BillInfoDAO.instance = value; }
        }

        private BillInfoDAO() { }

        public void DeleteBillInfoByFoodID(int IDFood)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfor where BI_IDFood = " + IDFood);
        }

        public void DeleteBillInfoByCategoryFoodID(int IDCategory)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfor where BI_IDFood = (select F_ID from dbo.Food where F_IDCategory = " + IDCategory + ")");
        }

        public void DeleteBillInfoByTableFoodID(int IDTable)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.BillInfor where BI_IDBill = (select B_ID from dbo.Bill where B_IDTable = " + IDTable + " and B_Status = 0)");
        }

        public List<BillInfo> GetListBillInfo(int IDBill)
        {
            List<BillInfo> listBillInfo = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfor where BI_IDBill = " + IDBill);
            foreach (DataRow item in data.Rows)
            {
                BillInfo info = new BillInfo(item);
                listBillInfo.Add(info);
            }
            return listBillInfo;
        }

        public void insertBillInfo(int IDBill, int IDFood, int Total)
        {
            DataProvider.Instance.ExecuteQuery("USP_InsertBillInfo @BI_IDBill , @BI_IDFood , @BI_Total", new object[] { IDBill, IDFood, Total });
        }
    }
}
