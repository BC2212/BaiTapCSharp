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
        public Login()
        {
            InitializeComponent();
            //btnLogin.Location = Point(Form.Size[0])
        }

        private void SignIn_Load(object sender, EventArgs e)
        {

        }

        private void lblTitleQLSV_Click(object sender, EventArgs e)
        {

        }

        private void tbloginMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            

            List<Account> listAccounts = new List<Account>();

            if(Account.LogIn(listAccounts, txtTaiKhoan.Text, txtMatKhau.Text) >= 0)
            {
                ThongTinSV frmThongTinSV = new ThongTinSV();
                frmThongTinSV.Enabled = true;
                frmThongTinSV.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai ten dang nhap hoac mat khau");
                txtTaiKhoan.Text = "";
                txtMatKhau.Text = "";
                txtTaiKhoan.Focus();
            }
        }

        private void lblQuenMatKhau_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
