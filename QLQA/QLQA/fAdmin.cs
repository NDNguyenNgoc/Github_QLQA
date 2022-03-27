using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLQA.DAO;
using QLQA.DTO;

namespace QLQA
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();

        BindingSource foodCategoryList = new BindingSource();

        BindingSource tableList = new BindingSource();

        BindingSource accountList = new BindingSource();

        BindingSource staffList = new BindingSource();

        public Account loginAccount;

        public fAdmin()
        {
            InitializeComponent();
            LoadAll();
        }

        void LoadAll()
        {
            dgvListFood.DataSource = foodList;
            dgvListCategory.DataSource = foodCategoryList;
            dgvListTable.DataSource = tableList;
            dgvListAccount.DataSource = accountList;
            dgvListStaff.DataSource = staffList;

            LoadDateTimePickerBill();
            LoadListBillByDate(dtpFrom.Value, dtpTo.Value);
            LoadListTable();
            LoadListCategory();
            LoadListFood();
            LoadAccount();
            LoadListStaff();

            LoadCategoryIntoCombobox(cbCategoryFood);

            AddTableBinding();
            AddCategoryBinding();
            AddFoodBinding();
            AddAccountBinding();
            AddStaffBinding();
        }

        #region methods
        /*Binding*/
        void AddAccountBinding()
        {
            txbUserName.DataBindings.Add(new Binding("Text", dgvListAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txbViewName.DataBindings.Add(new Binding("Text", dgvListAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nudTypeAcc.DataBindings.Add(new Binding("Value", dgvListAccount.DataSource, "A_IDStaff", true, DataSourceUpdateMode.Never));
            txbIDStaff.DataBindings.Add(new Binding("Text", dgvListAccount.DataSource, "A_Type", true, DataSourceUpdateMode.Never));
        }

        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dgvListFood.DataSource, "F_Name", true, DataSourceUpdateMode.Never));
            txbIdFood.DataBindings.Add(new Binding("Text", dgvListFood.DataSource, "F_ID", true, DataSourceUpdateMode.Never));
            nudFunds.DataBindings.Add(new Binding("Value", dgvListFood.DataSource, "F_Funds", true, DataSourceUpdateMode.Never));
            nudPrice.DataBindings.Add(new Binding("Value", dgvListFood.DataSource, "F_Price", true, DataSourceUpdateMode.Never));
        }

        void AddCategoryBinding()
        {
            txbCategoryID.DataBindings.Add(new Binding("Text", dgvListCategory.DataSource, "CF_ID", true, DataSourceUpdateMode.Never));
            txbCategoryName.DataBindings.Add(new Binding("Text", dgvListCategory.DataSource, "CF_Name", true, DataSourceUpdateMode.Never));
        }

        void AddTableBinding()
        {
            txbTableID.DataBindings.Add(new Binding("Text", dgvListTable.DataSource, "TF_ID", true, DataSourceUpdateMode.Never));
            txbTableName.DataBindings.Add(new Binding("Text", dgvListTable.DataSource, "TF_Name", true, DataSourceUpdateMode.Never));
            txbStatus.DataBindings.Add(new Binding("Text", dgvListTable.DataSource, "TF_Status", true, DataSourceUpdateMode.Never));
        }

        void AddStaffBinding()
        {
            txbStaffID.DataBindings.Add(new Binding("Text", dgvListStaff.DataSource, "S_ID", true, DataSourceUpdateMode.Never));
            txbStaffName.DataBindings.Add(new Binding("Text", dgvListStaff.DataSource, "S_Name", true, DataSourceUpdateMode.Never));
            txbStaffPhone.DataBindings.Add(new Binding("Text", dgvListStaff.DataSource, "S_PhoneNumber", true, DataSourceUpdateMode.Never));
            txbCMND.DataBindings.Add(new Binding("Text", dgvListStaff.DataSource, "S_IdentityCard", true, DataSourceUpdateMode.Never));
            nudWage.DataBindings.Add(new Binding("Value", dgvListStaff.DataSource, "S_Salary", true, DataSourceUpdateMode.Never));
        }

        /*Load list*/
        void LoadAccount()
        {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }

        void LoadListCategory()
        {
            foodCategoryList.DataSource = CategoryDAO.Instance.GetListCategory();
        }

        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void LoadListStaff()
        {
            staffList.DataSource = StaffDAO.Instance.GetListStaff();
        }

        void LoadListTable()
        {
            tableList.DataSource = TableDAO.Instance.GetListTable();
        }

        List<Food> SearchFoodByName (string f_Name)
        {
            List<Food> listFood = FoodDAO.Instance.SearchFoodByName(f_Name);
            return listFood;
        }

        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpTo.Value = dtpFrom.Value.AddMonths(1).AddDays(-1);
        }

        void LoadListBillByDate(DateTime datecheckin, DateTime datechekout)
        {
            dgvListBill.DataSource = BillDAO.Instance.GetListBillByDate(datecheckin, datechekout);
            dgvStatistical.DataSource = BillDAO.Instance.GetTotalPriceByDate(datecheckin, datechekout);
        }       

        void LoadCategoryIntoCombobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "CF_Name";
        }

        private void txbIDmon_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvListFood.SelectedCells.Count > 0)
                {
                    int id = (int)dgvListFood.SelectedCells[0].OwningRow.Cells["CF_ID"].Value;
                    Category category = CategoryDAO.Instance.GetCategoryById(id);
                    cbCategoryFood.SelectedItem = category;
                    int index = -1;
                    int i = 0;

                    foreach (Category item in cbCategoryFood.Items)
                    {
                        if(item.CF_ID == category.CF_ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbCategoryFood.SelectedIndex = index;
                }
            }
            catch { }
        }

        void AddAccount (string UserName, string DisplayName, int IDStaff, int Type)
        {
            if (AccountDAO.Instance.InsertAccount(UserName, DisplayName, IDStaff, Type))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản không thành công!");
            }
            LoadAccount();
        }

        void EditAccount(string UserName, string DisplayName, int IDStaff, int Type)
        {
            if (AccountDAO.Instance.UpdateAccount(UserName, DisplayName, IDStaff, Type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật tài khoản không thành công!");
            }
            LoadAccount();
        }

        void DeleteAccount(string UserName)
        {
            if (loginAccount.UserName.Equals(UserName))
            {
                MessageBox.Show("Không thể xóa tài khoản hiện hành!");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(UserName))
            {
                MessageBox.Show("Xóa tài khoản thành công!");
            }
            else
            {
                MessageBox.Show("Xóa tài khoản không thành công!");
            }
            LoadAccount();
        }

        void ResetPass (string UserName)
        {
            if (AccountDAO.Instance.ResetPass(UserName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công!");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu không thành công!");
            }
        }

        void AddStaff(string S_Name, string S_PhoneNumber, string S_IdentityCard, int S_Salary)
        {
            if (StaffDAO.Instance.InsertStaff(S_Name, S_PhoneNumber, S_IdentityCard, S_Salary))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Thêm nhân viên không thành công!");
            }
            LoadListStaff();
        }

        void EditStaff(int S_ID, string S_Name, string S_PhoneNumber, string S_IdentityCard, int S_Salary)
        {
            if (StaffDAO.Instance.UpdateStaff(S_ID, S_Name, S_PhoneNumber, S_IdentityCard, S_Salary))
            {
                MessageBox.Show("Cập nhật nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Cập nhật nhân viên không thành công!");
            }
            LoadListStaff();
        }

        void DeleteStaff(int S_ID)
        {
            if (loginAccount.A_IDStaff.Equals(S_ID))
            {
                MessageBox.Show("Không thể xóa nhân viên chủ tài khoản hiện hành!");
                return;
            }
            if (StaffDAO.Instance.DeleteStaff(S_ID))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
            }
            else
            {
                MessageBox.Show("Xóa nhân viên không thành công!");
            }
            LoadListStaff();
            LoadAccount();
        }

        void AddTable(string TF_Name)
        {
            if (TableDAO.Instance.InsertTable(TF_Name))
            {
                MessageBox.Show("Thêm bàn thành công!");
                LoadListTable();

                if (insertTableFood != null)
                    insertTableFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm bàn không thành công!");
            }
        }

        void EditTable(int TF_ID, string TF_Name, string TF_Status)
        {
            if (TableDAO.Instance.UpdateTable(TF_ID, TF_Name, TF_Status))
            {
                MessageBox.Show("Cập nhật bàn thành công!");
                LoadListTable();

                if (updateTableFood != null)
                    updateTableFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Cập nhật bàn không thành công!");
            }
        }

        void DeleteTable(int TF_ID)
        {
            if (TableDAO.Instance.DeleteTable(TF_ID))
            {
                MessageBox.Show("Xóa bàn thành công!");
                LoadListTable();

                if (deleteTableFood != null)
                    deleteTableFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa bàn không thành công!");
            }
        }

        void AddCategoryFood(string CF_Name)
        {
            if (CategoryDAO.Instance.InsertCategoryFood(CF_Name))
            {
                MessageBox.Show("Thêm danh mục thành công!");
                LoadListCategory();
                LoadListFood();
                LoadCategoryIntoCombobox(cbCategoryFood);

                if (insertCategoryFoodEV != null)
                    insertCategoryFoodEV(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm danh mục không thành công!");
            }
        }

        void EditCategoryFood(int CF_ID, string CF_Name)
        {
            if (CategoryDAO.Instance.UpdateCategoryFood(CF_ID, CF_Name))
            {
                MessageBox.Show("Cập nhật danh mục thành công!");
                LoadListCategory();
                LoadListFood();
                LoadCategoryIntoCombobox(cbCategoryFood);

                if (updateCategoryFoodEV != null)
                    updateCategoryFoodEV(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Cập nhật danh mục không thành công!");
            }
        }

        void DeleteCategoryFood(int CF_ID)
        {

            if (CategoryDAO.Instance.DeleteCategoryFood(CF_ID))
            {
                MessageBox.Show("Xóa danh mục thành công!");
                LoadListCategory();
                LoadListFood();
                LoadCategoryIntoCombobox(cbCategoryFood);

                if (deleteCategoryFoodEV != null)
                    deleteCategoryFoodEV(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa danh mục không thành công!");
            }
        }
        #endregion

        #region event
        /*EventHandler*/
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler insertTableFood;
        public event EventHandler InsertTableFood
        {
            add { insertTableFood += value; }
            remove { insertTableFood -= value; }
        }

        private event EventHandler updateTableFood;
        public event EventHandler UpdateTableFood
        {
            add { updateTableFood += value; }
            remove { updateTableFood -= value; }
        }

        private event EventHandler deleteTableFood;
        public event EventHandler DeleteTableFood
        {
            add { deleteTableFood += value; }
            remove { deleteTableFood -= value; }
        }

        private event EventHandler insertCategoryFoodEV;
        public event EventHandler InsertCategoryFoodEV
        {
            add { insertCategoryFoodEV += value; }
            remove { insertCategoryFoodEV -= value; }
        }

        private event EventHandler updateCategoryFoodEV;
        public event EventHandler UpdateCategoryFoodEV
        {
            add { updateCategoryFoodEV += value; }
            remove { updateCategoryFoodEV -= value; }
        }

        private event EventHandler deleteCategoryFoodEV;
        public event EventHandler DeleteCategoryFoodEV
        {
            add { deleteCategoryFoodEV += value; }
            remove { deleteCategoryFoodEV -= value; }
        }

        /*bottom Bill*/
        private void btnStatistical_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpFrom.Value, dtpTo.Value);
        }

        /*bottom view*/
        //private void btnViewTable_Click(object sender, EventArgs e)
        //{
        //    LoadListTable();
        //}

        //private void btnViewCategory_Click(object sender, EventArgs e)
        //{
        //    LoadListCategory();
        //}

        //private void btnViewFood_Click(object sender, EventArgs e)
        //{
        //    LoadListFood();
        //}

        //private void btnViewStaff_Click(object sender, EventArgs e)
        //{
        //    LoadListStaff();
        //}

        //private void btnViewAcc_Click(object sender, EventArgs e)
        //{
        //    LoadAccount();
        //}


        /*bottom Table*/
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string tableName = txbTableName.Text;
            AddTable(tableName);
        }

        private void btnFixTable_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbTableID.Text);
            string tableName = txbTableName.Text;
            string tableStatus = txbStatus.Text;
            EditTable(idTable, tableName, tableStatus);
        }

        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int idTable = Convert.ToInt32(txbTableID.Text);
            DeleteTable(idTable);
        }


        /*bottom Category Food*/
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string categoryName = txbCategoryName.Text;
            AddCategoryFood(categoryName);
        }

        private void btnFixCategory_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(txbCategoryID.Text);
            string categoryName = txbCategoryName.Text;
            EditCategoryFood(idCategory, categoryName);
        }

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int idCategory = Convert.ToInt32(txbCategoryID.Text);
            DeleteCategoryFood(idCategory);
        }


        /*bottom Food*/
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string foodName = txbFoodName.Text;
            int idCategoryFood = (cbCategoryFood.SelectedItem as Category).CF_ID;
            float funds = (float)nudFunds.Value;
            float price = (float)nudPrice.Value;

            if (FoodDAO.Instance.InsertFood(foodName, idCategoryFood, funds, price))
            {
                MessageBox.Show("Thêm món thành công!");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Thêm món không thành công!\n Kiểm tra lại thông tin món cần thêm.");
            }
        }

        private void btnFixFood_Click(object sender, EventArgs e)
        {
            int idFood = Convert.ToInt32(txbIdFood.Text);
            string foodName = txbFoodName.Text;
            int idCategoryFood = (cbCategoryFood.SelectedItem as Category).CF_ID;
            float funds = (float)nudFunds.Value;
            float price = (float)nudPrice.Value;

            if (FoodDAO.Instance.UpdateFood(idFood, foodName, idCategoryFood, funds, price))
            {
                MessageBox.Show("Sửa món thành công!");
                LoadListFood();

                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Sửa món không thành công!\n Kiểm tra lại thông tin món cần sửa.");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int idFood = Convert.ToInt32(txbIdFood.Text);

            if (FoodDAO.Instance.DeleteFood(idFood))
            {
                MessageBox.Show("Xóa món thành công!");
                LoadListFood();

                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Xóa món không thành công!\n Đã xảy ra lỗi trong quá trình xóa.");
            }
        }

        private void btnSeachFood_Click(object sender, EventArgs e)
        {
            foodList.DataSource = SearchFoodByName(txbSeachFood.Text);
        }


        /*bottom Staff*/
        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string staffName = txbStaffName.Text;
            string staffPhone = txbStaffPhone.Text;
            string staffCard = txbCMND.Text;
            int staffWage = (int)nudWage.Value;

            AddStaff(staffName, staffPhone, staffCard, staffWage);
        }

        private void btnFixStaff_Click(object sender, EventArgs e)
        {
            int staffID = Convert.ToInt32(txbStaffID.Text);
            string staffName = txbStaffName.Text;
            string staffPhone = txbStaffPhone.Text;
            string staffCard = txbCMND.Text;
            int staffWage = (int)nudWage.Value;

            EditStaff(staffID, staffName, staffPhone, staffCard, staffWage);
        }

        private void btnDeleteStaff_Click(object sender, EventArgs e)
        {
            int staffID = Convert.ToInt32(txbStaffID.Text);
            DeleteStaff(staffID);
        }


        /*bottom Account*/
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbViewName.Text;
            int idStaff = Convert.ToInt32(txbIDStaff.Text);
            int typeAccount = (int)nudTypeAcc.Value;

            AddAccount(userName, displayName, idStaff, typeAccount);
        }

        private void btnFixAccount_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string displayName = txbViewName.Text;
            int idStaff = Convert.ToInt32(txbIDStaff.Text);
            int typeAccount = (int)nudTypeAcc.Value;

            EditAccount(userName, displayName, idStaff, typeAccount);
        }

        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            DeleteAccount(userName);
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            ResetPass(userName);
        }
        #endregion
    }
}
