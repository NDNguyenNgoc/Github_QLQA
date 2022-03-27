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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        bool login (string UserName, string PassWord)
        {
            return AccountDAO.Instance.login(UserName, PassWord);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = txbUsername.Text;
            string PassWord = txbPassword.Text;

            if (login(UserName, PassWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUsername(UserName);
                fTableManager f = new fTableManager (loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
