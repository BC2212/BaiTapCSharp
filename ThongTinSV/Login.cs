using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLSV.Lib;

namespace ThongTinSV
{
    public partial class Login : Form
    {
        public static List<Account> listAccounts;

        public Login()
        {
            InitializeComponent();
            string accountPath = string.Format($@"{Application.StartupPath}\dataAccount.xlsx");

            listAccounts = Data.GetAccountsFromExcel(accountPath);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetFormValue()
        {
            txtTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtTaiKhoan.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Biến checkLogin nhận giá trị từ hàm Login là permission của account
            //Giá trị là -1: Sai tài khoản hoặc mật khẩu
            int checkLogin = Account.LogIn(listAccounts, txtTaiKhoan.Text, txtMatKhau.Text);

            if(checkLogin >= 0)
            {
                ThongTinSV frmThongTinSV = new ThongTinSV();
                frmThongTinSV.Enabled = true;

                frmThongTinSV.Sender(txtTaiKhoan.Text);

                this.Hide();
                frmThongTinSV.ShowDialog();
                this.ResetFormValue();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai ten dang nhap hoac mat khau");
                ResetFormValue();
            }
        }
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTaoTaiKhoan_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
