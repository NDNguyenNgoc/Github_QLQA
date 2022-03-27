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
    public partial class fInfor : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount); }
        }

        public fInfor(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txbUserName.Text = LoginAccount.UserName;
            txbDisplayName.Text = LoginAccount.DisplayName;
        }

        void UpdateAccountInfo()
        {
            string displayName = txbDisplayName.Text;
            string passWord = txbPassWord.Text;
            string newPass = txbNewPass.Text;
            string reEnterPass = txbPassA.Text;
            string userName = txbUserName.Text;

            if (!newPass.Equals(reEnterPass))
            {
                MessageBox.Show("Mật khẩu xác nhận sai!\n Vui lòng nhập lại mật khẩu và mật khẩu xác nhận");
            }
            else
            {
                if (AccountDAO.Instance.updateAccount(userName, displayName, passWord, newPass))
                {
                    MessageBox.Show("Cập nhật thành công!");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAO.Instance.GetAccountByUsername(userName)));
                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại mật khẩu!");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent> UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }

        private void btnSigOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }
    }
    public class AccountEvent : EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }

        public AccountEvent(Account acc)
        {
            this.Acc = acc;
        }
    }
}
