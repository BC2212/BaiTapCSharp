using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Lib
{
    public class SinhVien
    {
        //Index là vị trí dòng của một sinh viên lấy ra từ excel
        private int index;
        private string maSV;
        private string hoTen;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string diaChi;
        private string khoa;
        private string lop;
        private string sdt;
        private string email;
        private string username;

        public int Index { get => index; set => index = value; }
        public string MaSV { get => maSV; set => maSV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Khoa { get => khoa; set => khoa = value; }
        public string Lop { get => lop; set => lop = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }

        public SinhVien()
        {
            this.Index = 0;
            this.MaSV = "";
            this.HoTen = "";
            this.NgaySinh = new DateTime();
            this.GioiTinh = "";
            this.DiaChi = "";
            this.Khoa = "";
            this.Lop = "";
            this.Sdt = "";
            this.Email = "";
            this.Username = "";
        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, string gioiTinh, string diaChi, string khoa, string lop, string sdt, string email, string username, int index=0)
        {
            this.Index = index;
            this.MaSV = maSV;
            this.HoTen = hoTen;
            this.NgaySinh = ngaySinh;
            this.GioiTinh = gioiTinh;
            this.DiaChi = diaChi;
            this.Khoa = khoa;
            this.Lop = lop;
            this.Sdt = sdt;
            this.Email = email;
            this.Username = username;
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

        public static int IndexOfSinhVien(List<SinhVien> listSinhVien, string username)
        {
            return listSinhVien.FindIndex(delegate (SinhVien sinhVien)
            {
                return sinhVien.Username.Equals(username);
            });
        }

        //Tìm sinh viên theo mã sinh viên
        //Trả về khác -1: index của sinh viên đó trong list
        //Trả về -1: không tìm được
        public static int IndexOfSinhVienByMSSV(List<SinhVien> listSinhVien, string mssv)
        {
            return listSinhVien.FindIndex(delegate (SinhVien sinhVien)
            {
                return sinhVien.MaSV.Equals(mssv);
            });
        }

        public static void PrintAllSinhVien(List<SinhVien> listSinhVien)
        {
            foreach(SinhVien sinhvien in listSinhVien)
            {
                Console.WriteLine(sinhvien.Index);
                Console.WriteLine(sinhvien.MaSV);
                Console.WriteLine(sinhvien.HoTen);
                Console.WriteLine(sinhvien.NgaySinh.ToString());
                Console.WriteLine(sinhvien.GioiTinh);
                Console.WriteLine(sinhvien.DiaChi);
                Console.WriteLine(sinhvien.Khoa);
                Console.WriteLine(sinhvien.Lop);
                Console.WriteLine(sinhvien.Sdt);
                Console.WriteLine(sinhvien.Email);
                Console.WriteLine(sinhvien.Username);
            }
        }
    }
}
