using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.Lib.Quan_Ly_Thong_Tin_SV
{
    class XuLy_ThongTin_Func
    {
        // lSV List SinhVien
        // sv data Sinh Vien them vao list
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
