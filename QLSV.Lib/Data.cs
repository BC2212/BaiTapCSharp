using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace QLSV.Lib
{
    public class Data
    {
        private static Excel.Application xlApp;
        private static Excel.Workbook xlWorkBook;
        private static Excel.Worksheet xlWorksheet;
        private static string sysDateFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

        //Trả về range của một worksheet
        private static Excel.Range GetRangeOfWorksheet(Excel.Worksheet worksheet)
        {
            return worksheet.UsedRange;
        }

        //Trả về số dòng có trong Worksheet
        private static int GetNumberOfRows(Excel.Range range)
        {
            return range.Rows.Count;
        }

        //Trả về số cột có trong Worksheet
        private int GetNumberOfColumns(Excel.Range range)
        {
            return range.Columns.Count;
        }

        //Hàm lấy dữ liệu cho Account
        private static Account GetAccount(Excel.Range range, int row)
        {
            Account account = new Account();

            account.Username = (string)(range.Cells[row, 1] as Excel.Range).Value2;
            account.Password = (string)(range.Cells[row, 2] as Excel.Range).Value2;
            account.Salt = (string)(range.Cells[row, 3] as Excel.Range).Value2;
            account.Type = (byte)(range.Cells[row, 4] as Excel.Range).Value2;
            account.Permission = (int)(range.Cells[row, 5] as Excel.Range).Value2;

            return account;
        }

        //Hàm lấy dữ liệu cho Sinh viên
        private static SinhVien GetSinhVien(Excel.Range range, int row)
        {
            SinhVien sv = new SinhVien();

            sv.MaSV = (range.Cells[row, 1] as Excel.Range).Value2.ToString();
            sv.HoTen = (string)(range.Cells[row, 2] as Excel.Range).Value2;

            string tmpNgaySinh = (string)(range.Cells[row, 3] as Excel.Range).Value2;
            sv.NgaySinh = DateTime.ParseExact(tmpNgaySinh, sysDateFormat, CultureInfo.InvariantCulture);
            
            sv.GioiTinh = (string)(range.Cells[row, 4] as Excel.Range).Value2;
            sv.DiaChi = (string)(range.Cells[row, 5] as Excel.Range).Value2;
            sv.Khoa = (string)(range.Cells[row, 6] as Excel.Range).Value2;
            sv.Lop = (string)(range.Cells[row, 7] as Excel.Range).Value2;
            sv.Sdt = (string)(range.Cells[row, 8] as Excel.Range).Value2;
            sv.Email = (string)(range.Cells[row, 9] as Excel.Range).Value2;
            sv.Username = (string)(range.Cells[row, 10] as Excel.Range).Value2;

            return sv;
        }

        public static List<SinhVien> GetSinhViensFromExcel(string path, int worksheetNumber = 1)
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(worksheetNumber);

            Excel.Range range = GetRangeOfWorksheet(xlWorksheet);

            int rw = GetNumberOfRows(range);


            List<SinhVien> listSinhViens = new List<SinhVien>();

            for (int rCnt = 2; rCnt <= rw; rCnt++)
            {
                SinhVien sinhVien = GetSinhVien(range, rw);
                if (sinhVien.MaSV == "")
                    continue;
                listSinhViens.Add(sinhVien);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlWorksheet);
            xlWorkBook.Close();
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            return listSinhViens;
        }

        public static List<Account> GetAccountsFromExcel(string path, int worksheetNumber = 1)
        {
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(worksheetNumber);

            Excel.Range range = GetRangeOfWorksheet(xlWorksheet);

            int rw = GetNumberOfRows(range);


            List<Account> listAccounts = new List<Account>();

            for (int rCnt = 2; rCnt <= rw; rCnt++)
            {
                Account account = GetAccount(range, rw);
                if (account.Username == "")
                    continue;
                account.Index = rCnt;
                listAccounts.Add(account);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlWorksheet);
            xlWorkBook.Close();
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            return listAccounts;
        }
        //ham write data
        //static void Main(string[] args  )
        //{
        //    Excel._Application myExcelApp;
        //    Excel.Workbooks myExcelWorkbooks;
        //    Excel.Workbook myExcelWorkbook;
        //    // Excel ._Worksheet myExccelWorksheetToChange;
        //    object misValue = System.Reflection.Missing.Value;

        //    myExcelApp = new Excel.Application();
        //    myExcelApp.Visible = true;
        //    myExcelWorkbooks = myExcelApp.Workbooks;
        //    String fileName = path;
        //    myExcelWorkbook = myExcelWorkbooks.Open(fileName, misValue, misValue, misValue, misValue,
        //    misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);

        //    Excel.Worksheet myExcelWorksheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

        //    String cellFormulaAsString = myExcelWorksheet.get_Range("A2", misValue).Formula.ToString();

        //    myExcelWorksheet.get_Range("A2", misValue).Formula = Console.ReadLine();

        //}

    }
}
