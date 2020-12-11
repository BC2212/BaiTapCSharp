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
using QLSV.Lib.Quan_Ly_Thong_Tin_SV;

namespace ThongTinSV
{
    public partial class ThongTinSV : Form
    {
        List<SinhVien> SV = new List<SinhVien>();
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMSSV.Text != "" && txtName.Text != "" && txtNgaySinh.Text != "" && txtGioiTinh.Text != "" && txtDiaChi.Text != "" && txtLop.Text != "" && txtKhoa.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
            {
                SinhVien sv = new SinhVien();
                sv.MaSV = txtMSSV.Text;
                sv.HoTenSV = txtName.Text;
                sv.NgaySinh = txtNgaySinh.Text;
                sv.GioiTinh = txtGioiTinh.Text;
                sv.DiaChi = txtDiaChi.Text;
                sv.Lop = txtLop.Text;
                sv.Khoa = txtKhoa.Text;
                sv.SDT = txtSDT.Text;
                sv.Gmail = txtEmail.Text;
                SV.Add(sv);
            }
        }
    }
}
