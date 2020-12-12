using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Lib.Quan_Ly_Thong_Tin_SV
{
    public class SinhVien
    {
        private string maSV;
        private string hoTen;
        private DateTime ngaySinh;
        private bool gioiTinh;
        private string diaChi;
        private string khoa;
        private string lop;
        private string sdt;
        private string email;

        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public bool GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }

        public SinhVien()
        {
            this.MaSV = "";
            this.HoTen = "";
            this.NgaySinh = new DateTime();
            this.GioiTinh = false;
            this.DiaChi = "";
            this.Khoa = "";
            this.Lop = "";
            this.Sdt = "";
            this.Email = "";
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, bool gioiTinh, string diaChi, string khoa, string lop, string sdt, string email)
        {
            this.MaSV = maSV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.Khoa = khoa;
            this.Lop = lop;
            this.Sdt = sdt;
            this.Email = email;
        }

        public void ThemSinhVien(ref List<SinhVien> lSV, SinhVien sv)
        {
            lSV.Add(sv);
        }

        //maSV Ma Sinh Vien xoa tu list
        public void XoaSinhVien(ref List<SinhVien> lSV, String maSV)
        {
            int count = 0;
            foreach (SinhVien item in lSV)
            {
                if (item.MaSV == maSV)
                {
                    lSV.RemoveAt(count);
                    break;
                }
                count++;
            }
        }

        //sv Data 1 SinhVien
        public void SuaSinhVien(ref List<SinhVien> lSV, SinhVien sv)
        {
            int count = 0;
            foreach (SinhVien item in lSV)
            {
                if (item.MaSV == sv.MaSV)
                {
                    lSV[count] = sv;
                    break;
                }
                count++;
            }
        }
    }
}
