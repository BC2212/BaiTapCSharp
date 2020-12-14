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

        private string CheckDate(SinhVien sv)
        {
            return (sv.NgaySinh.ToShortDateString() == DateTime.Now.ToShortDateString()) ? string.Empty : sv.NgaySinh.ToShortDateString();
        }

        private ListViewItem AddSVToListViewItem(SinhVien sv)
        {
            ListViewItem LVItem = new ListViewItem(sv.MaSV);

            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, sv.HoTen));

            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, CheckDate(sv)));

            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, sv.GioiTinh));
            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, sv.DiaChi));
            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, sv.Khoa));
            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, sv.Lop));
            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, sv.Sdt));
            LVItem.SubItems.Add(new ListViewItem.ListViewSubItem(LVItem, sv.Email));

            return LVItem;
        }

        private void mnuTiemKiem_Click(object sender, EventArgs e)
        {
            lstvTimKiem.Items.Clear();
            plTiemKiem.Visible = true;
            txtTimKiem.Text = "";

            foreach(SinhVien sv in listSinhVien)
            {
                lstvTimKiem.Items.Add(AddSVToListViewItem(sv));
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            plTiemKiem.Visible = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lstvTimKiem.Items.Clear();
            if (!string.IsNullOrEmpty(txtTimKiem.Text))
            {
                int timKiem = SinhVien.IndexOfSinhVienByMSSV(listSinhVien, txtTimKiem.Text);

                if (timKiem != -1)
                {
                    lstvTimKiem.Items.Add(AddSVToListViewItem(listSinhVien[timKiem]));
                }
            }
        }

        private void mnuTTSV_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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

        private void lstvTimKiem_ItemActivate(object sender, EventArgs e)
        {
            txtMSSV.Text = lstvTimKiem.SelectedItems[0].SubItems[0].Text;
            txtName.Text = lstvTimKiem.SelectedItems[0].SubItems[1].Text;
            txtNgaySinh.Text = lstvTimKiem.SelectedItems[0].SubItems[2].Text;
            txtGioiTinh.Text = lstvTimKiem.SelectedItems[0].SubItems[3].Text;
            txtDiaChi.Text = lstvTimKiem.SelectedItems[0].SubItems[4].Text;
            txtKhoa.Text = lstvTimKiem.SelectedItems[0].SubItems[5].Text;
            txtLop.Text = lstvTimKiem.SelectedItems[0].SubItems[6].Text;
            txtSDT.Text = lstvTimKiem.SelectedItems[0].SubItems[7].Text;
            txtEmail.Text = lstvTimKiem.SelectedItems[0].SubItems[8].Text;

            plTiemKiem.Visible = false;
        }
    }
}
