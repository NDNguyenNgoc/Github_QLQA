using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLQA.DTO;

namespace QLQA.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();
            string query = "select * from dbo.CategoryFood";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }

        public Category GetCategoryById(int CF_ID)
        {
            Category category = null;
            string query = "select * from dbo.CategoryFood where CF_ID = " + CF_ID;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }

        public bool InsertCategoryFood(string CF_Name)
        {
            string query = string.Format("insert dbo.CategoryFood ( CF_Name) values ( N'{0}')", CF_Name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool UpdateCategoryFood(int CF_ID, string CF_Name)
        {
            string query = string.Format("update dbo.CategoryFood set CF_Name = N'{0}' where CF_ID = {1}", CF_Name, CF_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool DeleteCategoryFood(int CF_ID)
        {
            FoodDAO.Instance.DeleteFoodByCategoryFoodID(CF_ID);
            string query = string.Format("delete dbo.CategoryFood where CF_ID = {0}", CF_ID);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
