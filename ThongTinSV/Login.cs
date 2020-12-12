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
            //btnLogin.Location = Point(Form.Size[0])
            string path = string.Format($@"{Application.StartupPath}\dataAccount.xlsx");

            listAccounts = Data.GetDataFromExcel(path);
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
            
            if(Account.LogIn(listAccounts, txtTaiKhoan.Text, txtMatKhau.Text) >= 0)
            {
                ThongTinSV frmThongTinSV = new ThongTinSV();
                frmThongTinSV.Enabled = true;
                this.Hide();
                frmThongTinSV.ShowDialog();
                this.ResetFormValue();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai ten dang nhap hoac mat khau");
                this.ResetFormValue();
            }
        }

        private void lblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
