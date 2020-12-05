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

namespace QLSV.Lib {
    public class Data
    {
        private Excel.Application xlApp;
        private Excel.Workbook xlWorkBook;
        private Excel.Worksheet xlWorkSheet;
        private Excel.Range range;

        //Trả về số dòng có trong worksheet
        private int GetNumberOfRows(Excel.WorkSheet workSheet)
        {
            return workSheet.UsedRange.Rows.Count;
        }

        //Trả về số cột có trong worksheet
        private int GetNumberOfColumns(Excel.WorkSheet workSheet)
        {
            return workSheet.UsedRange.Columns.Count;
        }

        public static List<Account> GetDataFromExcel()
        {
            
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(@"C:\New folder\test.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int rw = GetNumberOfRows(xlWorkSheet);

            List<Account> listAccounts = new List<Account>();

            for (int rCnt = 2; rCnt <= rw; rCnt++)
            {
                string mssv = (string)(range.Cells[rCnt, 1] as Excel.Range).Value2;
                string ten = (string)(range.Cells[rCnt, 2] as Excel.Range).Value2;
                string sdt = (string)(range.Cells[rCnt, 3] as Excel.Range).Value2;
                if (mssv == null)
                {
                    continue;
                }
                listAccounts.Add(account);
            }

            foreach (Account account in listAccounts)
            {
                MessageBox.Show(account.ToString());
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlWorkSheet);
            xlWorkBook.Close();
            Marshal.ReleaseComObject(xlWorkBook);
            //xlWorkBook.Close(true, null, null);
            //xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
        }
    }
}