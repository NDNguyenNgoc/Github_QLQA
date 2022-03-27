using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLQA.DAO;
using QLQA.DTO;

namespace QLQA
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.A_Type); }
        }
        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwapTable);
        }

        #region Method
        void ChangeAccount(int Type)
        {
            tsmiAdmin.Enabled = Type == 0;
            tsmiInfor.Text += " (" + LoginAccount.DisplayName + ") ";
        }

        void LoadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategoryFood.DataSource = listCategory;
            cbCategoryFood.DisplayMember = "cF_Name";
        }

        void LoadFoodListByCategoryID (int cF_ID)
        {
            List<Food> listFood = FoodDAO.Instance.GetFoodByCategoryID(cF_ID);
            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "f_Name";
        }

        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.LoadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.TF_Name + Environment.NewLine + item.TF_Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                
                switch (item.TF_Status)
                {
                    case "Trống":
                        btn.BackColor = Color.LightGreen;
                        break;
                    default:
                        btn.BackColor = Color.Red;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int TF_ID)
        {
            lvBill.Items.Clear();
            List<Menu1> listBillInfo = Menu1DAO.Instance.GetListMenuByTable(TF_ID);

            float totalPrice = 0;
            float totalFunds = 0;

            foreach (Menu1 item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.F_Name.ToString());

                lsvItem.SubItems.Add(item.BI_Total.ToString());

                lsvItem.SubItems.Add(item.F_Price.ToString());

                lsvItem.SubItems.Add(item.TotalPrice.ToString());

                lsvItem.SubItems.Add(item.TotalFunds.ToString());

                totalPrice += item.TotalPrice;
                totalFunds += item.TotalFunds;

                lvBill.Items.Add(lsvItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            txbTotalPrice.Text = totalPrice.ToString();
            txbTotalFunds.Text = totalFunds.ToString();
        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "tF_Name";
        }
        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e)
        {
            int TF_ID = ((sender as Button).Tag as Table).TF_ID;
            lvBill.Tag = (sender as Button).Tag;
            ShowBill(TF_ID);
        }

        private void tsmiSigOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmiViewPersonalInformation_Click(object sender, EventArgs e)
        {
            fInfor f = new fInfor(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            tsmiViewPersonalInformation.Text = "Thông tin tài khoản (" + e.Acc.DisplayName + ") ";
        }

        private void tsmiAdmin_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.InsertCategoryFoodEV += F_InsertCategoryFoodEV;
            f.UpdateCategoryFoodEV += F_UpdateCategoryFoodEV;
            f.DeleteCategoryFoodEV += F_DeleteCategoryFoodEV;

            f.InsertTableFood += F_InsertTableFood;
            f.UpdateTableFood += F_UpdateTableFood;
            f.DeleteTableFood += F_DeleteTableFood;

            f.InsertFood += F_InsertFood;
            f.UpdateFood += F_UpdateFood;
            f.DeleteFood += F_DeleteFood;

            f.ShowDialog();
        }

        private void F_DeleteCategoryFoodEV(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).CF_ID);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).TF_ID);
            LoadTable();
        }

        private void F_UpdateCategoryFoodEV(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).CF_ID);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).TF_ID);
        }

        private void F_InsertCategoryFoodEV(object sender, EventArgs e)
        {
            LoadCategory();
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).CF_ID);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).TF_ID);
        }

        private void F_DeleteTableFood(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_UpdateTableFood(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_InsertTableFood(object sender, EventArgs e)
        {
            LoadTable();
        }

        private void F_UpdateFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).CF_ID);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).TF_ID);
        }

        private void F_InsertFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).CF_ID);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).TF_ID);
        }

        private void F_DeleteFood(object sender, EventArgs e)
        {
            LoadFoodListByCategoryID((cbCategoryFood.SelectedItem as Category).CF_ID);
            if (lvBill.Tag != null)
                ShowBill((lvBill.Tag as Table).TF_ID);
            LoadTable();
        }

        private void cbCategoryFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CF_ID = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;
            Category selected = cb.SelectedItem as Category;
            CF_ID = selected.CF_ID;
            LoadFoodListByCategoryID(CF_ID);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            if(table == null)
            {
                MessageBox.Show("Hãy chọn bàn!");
                return;
            }
            int B_ID = BillDAO.Instance.GetUncheckBillIDByTableID(table.TF_ID);
            int F_ID = (cbFood.SelectedItem as Food).F_ID;
            int Total = (int)nbudQuantily.Value;
            if(B_ID == -1)
            {
                BillDAO.Instance.insertBill(table.TF_ID, loginAccount.A_IDStaff);
                BillInfoDAO.Instance.insertBillInfo(BillDAO.Instance.GetMaxIDBill(), F_ID, Total);
            }
            else
            {
                BillInfoDAO.Instance.insertBillInfo(B_ID, F_ID, Total);
            }
            ShowBill(table.TF_ID);
            LoadTable();
        }

        private void btnBillPayment_Click(object sender, EventArgs e)
        {
            Table table = lvBill.Tag as Table;
            int B_ID = BillDAO.Instance.GetUncheckBillIDByTableID(table.TF_ID);
            int discount = (int)nbudDiscount.Value;

            double totalFunds = Convert.ToDouble(txbTotalFunds.Text.Split()[0]);
            double totalPrice = Convert.ToDouble(txbTotalPrice.Text.Split()[0]);
            double paymentHasDiscount = totalPrice - (totalPrice / 100) * discount;

            if (B_ID != -1)
            {
                if (MessageBox.Show(string.Format("Thanh toán hóa đơn bàn  {0}\n Tổng tiền - (Tổng tiền / 100) x giảm giá \n=> {1} - ({1} / 100) x {2} = {3}", table.TF_Name, totalPrice, discount, paymentHasDiscount), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(B_ID, discount, (float)paymentHasDiscount, (float)totalFunds);
                    ShowBill(table.TF_ID);
                    LoadTable();
                }
            }
        }

        private void btnSwapTable_Click(object sender, EventArgs e)
        {
            int idTable1 = (lvBill.Tag as Table).TF_ID;
            int idStaff1 = 0;
            if (TableDAO.Instance.GetIDStaffByTable(idTable1) == 0)
            {
                idStaff1 = LoginAccount.A_IDStaff;
            }
            else
            {
                idStaff1 = TableDAO.Instance.GetIDStaffByTable(idTable1);
            }
            int idTable2 = (cbSwapTable.SelectedItem as Table).TF_ID;
            int idStaff2 = 0;
            if (TableDAO.Instance.GetIDStaffByTable(idTable2) == 0)
            {
                idStaff2 = LoginAccount.A_IDStaff;
            }
            else
            {
                idStaff2 = TableDAO.Instance.GetIDStaffByTable(idTable2);
            }
            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển bàn {0} sang bàn {1}", (lvBill.Tag as Table).TF_Name, (cbSwapTable.SelectedItem as Table).TF_Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(idTable1, idTable2, idStaff1, idStaff2);
                LoadTable();
            }
        }
        #endregion


    }
}
