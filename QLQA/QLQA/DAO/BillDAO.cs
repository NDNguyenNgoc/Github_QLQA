using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;
        public static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return BillDAO.instance; }
            private set { BillDAO.instance = value; }
        }

        private BillDAO () { }

        public int GetUncheckBillIDByTableID(int IDTable)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where B_IDTable = " + IDTable + " and B_Status = 0");
            if (data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.B_ID;
            }
            return -1;
        }

        public void CheckOut(int B_ID, int B_Discount, float B_TotalPrice, float B_TotalFunds)
        {
            string query = "update dbo.Bill set DateCheckOut = getdate() , B_Status = 1," + " B_Discount = " + B_Discount + ", B_TotalPrice = " + B_TotalPrice + ",B_TotalFunds = " + B_TotalFunds + " where B_ID =" + B_ID;
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void insertBill(int IDTable, int IDStaff)
        {
            DataProvider.Instance.ExecuteQuery("exec USP_InsertBill @B_IDTable , @B_IDStaff", new object[] { IDTable, IDStaff });
        }

        public DataTable GetListBillByDate(DateTime datecheckin, DateTime datecheckout)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetListBillByDate @DateCheckIn , @DateCheckOut ", new object[] { datecheckin, datecheckout });
        }

        public DataTable GetTotalPriceByDate(DateTime datecheckin, DateTime datecheckout)
        {
            return DataProvider.Instance.ExecuteQuery("exec USP_GetTotalPriceByDate @DateCheckIn , @DateCheckOut ", new object[] { datecheckin, datecheckout });
        }

        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataProvider.Instance.ExecuteScalar("select max(B_ID) from dbo.Bill");
            }
            catch
            {
                return 1;
            }

        }

        public void DeleteBillByTableFoodID(int IDTable)
        {
            DataProvider.Instance.ExecuteQuery("delete dbo.Bill where B_IDTable = " + IDTable);
        }
    }
}
