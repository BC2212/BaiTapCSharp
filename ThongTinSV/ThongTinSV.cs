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
    public partial class ThongTinSV : Form
    {
        public List<SinhVien> listSinhVien;
        public delegate void SendMessage(string username);
        public SendMessage Sender;

        private static string username_Message;
        private static int permission_Message;

        public ThongTinSV()
        {
            InitializeComponent();
            Sender = new SendMessage(GetMessage);

            string sinhVienFilePath = string.Format($@"{Application.StartupPath}\dataSinhVien.xlsx");

            listSinhVien = Data.GetSinhViensFromExcel(sinhVienFilePath);

            DisableComponent();
        }

        private void ThongTinSV_Load(object sender, EventArgs e)
        {
            DisplaySinhVienDetail();
            
            
        }

        public void GetMessage(string username)
        {
            username_Message = username;
            //permission_Message = permission;
        }

        //Dùng permission_Message để kiểm tra
        //Có thể kiểm tra các quyền View, Edit, DeleteUser, Special
        private bool CheckUserPermission(int permissionNeedChecking)
        {
            return (permission_Message & permissionNeedChecking) == permissionNeedChecking ? true : false;
        }

        private void DisableFromViewPermission()
        {
            //Các textbox còn lại mặc định không được phép chỉnh sửa. Nên không cần thay đổi tại đây
            btnThem.Visible = false;
            btnSua.Visible = false;
            btnXoa.Visible = false;
        }

        private void DisableComponent()
        {
            //Các quyền được đại diện bằng int. Có thể gọi quyền từ class Permission
            if (CheckUserPermission(Permissions.View))
            {
                DisableFromViewPermission();
            }
        }

        private bool CheckUsernameExist()
        {
            return listSinhVien.Exists(x => x.Username == username_Message) ? true : false;
        }

        private void DisplaySinhVienDetail()
        {
            if (CheckUsernameExist())
            {
                int index = SinhVien.IndexOfSinhVien(listSinhVien, username_Message);

                txtMSSV.Text = listSinhVien[index].MaSV;
                txtName.Text = listSinhVien[index].HoTen;

                if (listSinhVien[index].NgaySinh.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    txtNgaySinh.Text = "";
                }
                else
                {
                    txtNgaySinh.Text = listSinhVien[index].NgaySinh.ToShortDateString();
                }

                txtGioiTinh.Text = listSinhVien[index].GioiTinh;
                txtDiaChi.Text = listSinhVien[index].DiaChi;
                txtLop.Text = listSinhVien[index].Lop;
                txtKhoa.Text = listSinhVien[index].Khoa;
                txtSDT.Text = listSinhVien[index].Sdt;
                txtEmail.Text = listSinhVien[index].Email;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(txtMSSV.Text != "" && txtName.Text != "" && txtNgaySinh.Text != "" && txtGioiTinh.Text != "" && txtDiaChi.Text != "" && txtLop.Text != "" && txtKhoa.Text != "" && txtSDT.Text != "" && txtEmail.Text != "")
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
    }
}
