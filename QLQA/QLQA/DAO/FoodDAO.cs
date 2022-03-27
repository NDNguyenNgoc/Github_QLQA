using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return FoodDAO.instance; }
            private set { FoodDAO.instance = value; }
        }

        private FoodDAO() { }

        public List<Food> GetFoodByCategoryID(int F_IDCategory)
        {
            List<Food> list = new List<Food>();
            string query = "select * from dbo.Food where F_IDCategory = " + F_IDCategory;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public List<Food> GetListFood()
        {
            List<Food> list = new List<Food>();
            string query = "select * from dbo.Food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public List<Food> SearchFoodByName(string F_Name)
        {
            List<Food> list = new List<Food>();
            string query = string.Format("select * from dbo.Food where dbo.fuConvertToUnsign1(F_Name) like N'%' + dbo.fuConvertToUnsign1(N'{0}') + '%'", F_Name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);
            }
            return list;
        }

        public bool InsertFood(string F_Name, int F_IDCategory, float F_Funds, float F_Price)
        {
            string query = string.Format("insert dbo.Food ( F_Name, F_IDCategory, F_Funds, F_Price) values ( N'{0}', {1}, {2}, {3})", F_Name, F_IDCategory, F_Funds, F_Price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateFood(int F_ID, string F_Name, int F_IDCategory, float F_Funds, float F_Price)
        {
            string query = string.Format("update dbo.Food set F_Name = N'{0}', F_IDCategory = {1}, F_Funds = {2}, F_Price = {3} where F_ID = {4} ", F_Name, F_IDCategory, F_Funds, F_Price, F_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteFood(int F_ID)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(F_ID);
            string query = string.Format("delete dbo.Food where F_ID = {0}", F_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public void DeleteFoodByCategoryFoodID(int F_IDCategory)
        {
            BillInfoDAO.Instance.DeleteBillInfoByCategoryFoodID(F_IDCategory);
            DataProvider.Instance.ExecuteQuery("delete dbo.Food where F_IDCategory = " + F_IDCategory);
        }
    }
}
