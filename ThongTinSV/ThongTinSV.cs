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
using System.Diagnostics;


namespace ThongTinSV
{
    public partial class ThongTinSV : Form
    {
        public List<SinhVien> ListSinhVien;

        public ThongTinSV()
        {
            InitializeComponent();
        }

        private void ThongTinSV_Load(object sender, EventArgs e)
        {

        }

        private void lblTTSV_Click(object sender, EventArgs e)
        {

        }
        private void ResetFormValue()
        {
            txtMSSV.Text = "";
            txtName.Text = "";
            txtNgaySinh.Text = "";
            txtGioiTinh.Text = "";
            txtDiaChi.Text = "";
            txtLop.Text = "";
            txtKhoa.Text = "";
            txtSDT.Text = "";
            txtEmail.Text = "";
            txtMSSV.Focus();
        }


        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
            System.Windows.Forms.Application.Exit();
        }

        private void mnuTiemKiem_Click(object sender, EventArgs e)
        {
            plTiemKiem.Visible = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            plTiemKiem.Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }


        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
        }

        private void plTiemKiem_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mnuTTSV_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lstvTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Txt = "Trống"
            ResetFormValue();
            //Ẩn nút thêm
            btnThem.Hide();
            //Hiện nút Ok
            btnThemOk.Show();





            if (txtMSSV.Text != "" && txtName.Text != "" && txtNgaySinh.Text != "" && txtGioiTinh.Text != "" && txtDiaChi.Text != "" && txtLop.Text != "" && txtKhoa.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
            {
                //SinhVien sv = new SinhVien();
                //sv.MaSV = txtMSSV.Text;
                //sv.HoTenSV = txtName.Text;
                //sv.NgaySinh = txtNgaySinh.Text;
                //sv.GioiTinh = txtGioiTinh.Text;
                //sv.DiaChi = txtDiaChi.Text;
                //sv.Lop = txtLop.Text;
                //sv.Khoa = txtKhoa.Text;
                //sv.SDT = txtSDT.Text;
                //sv.Gmail = txtEmail.Text;
                //SV.Add(sv);
            }
        }

        private void btnThemOk_Click(object sender, EventArgs e)
        {
            //Kiểm tra trống
            if (txtMSSV.Text == "")
            {
                MessageBox.Show(txtMSSV, "Mã sinh viên không được để trống!");
            }
            else if (txtName.Text == "")
            {
                MessageBox.Show(txtName, "Họ và tên không được để trống!");
            }
            else if (txtNgaySinh.Text == "")
            {
                MessageBox.Show(txtNgaySinh, "Ngày sinh không được để trống!");
            }
            else if (txtGioiTinh.Text == "")
            {
                MessageBox.Show(txtGioiTinh, "Ngày sinh không được để trống!");
            }
            else if (txtDiaChi.Text == "")
            {
                MessageBox.Show(txtName, "Địa chỉ không được để trống!");
            }
            else if (txtLop.Text == "")
            {
                MessageBox.Show(txtName, "Lớp không được để trống!");
            }
            else if (txtKhoa.Text == "")
            {
                MessageBox.Show(txtKhoa, "Khoa không được để trống!");
            }
            else if (txtSDT.Text == "")
            {
                MessageBox.Show(txtSDT, "Số điện thoại không được để trống!");
            }
            else if (txtEmail.Text == "")
            {
                MessageBox.Show(txtEmail, "Email không được để trống!");
            }
            //else if ()
            //{
            //    MessageBox.Show("Bạn đã nhập trùng mã sinh viên ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtMSSV.Focus();
            //}
            //else
            //{
            //    //Thực hiện truy vấn
            //    //String insert = 
            //}
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnSua.Hide();
            btnSuaOk.Show();
            txtMSSV.Enabled = true;
            txtName.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtDiaChi.Enabled = true;
            txtLop.Enabled = true;
            txtKhoa.Enabled = true;
            txtSDT.Enabled = true;
            txtEmail.Enabled = true;
        }

        private void btnSuaOk_Click(object sender, EventArgs e)
        {

        }

        
    }
}
