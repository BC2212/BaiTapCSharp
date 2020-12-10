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

namespace QLSV.Lib
{
    public class Data
    {
        private static Excel.Application xlApp;
        private static Excel.Workbook xlWorkBook;
        private static Excel.Worksheet xlWorksheet;
        private static Excel.Range range;

        //Trả về số dòng có trong Worksheet
        private static int GetNumberOfRows(Excel.Worksheet Worksheet)
        {
            return Worksheet.UsedRange.Rows.Count;
        }

        //Trả về số cột có trong Worksheet
        private int GetNumberOfColumns(Excel.Worksheet Worksheet)
        {
            return Worksheet.UsedRange.Columns.Count;
        }

        public static List<Account> GetDataFromExcel()
        {

            xlApp = new Excel.Application();
            string path = string.Format(@"{0}\data.xlsx", Application.StartupPath);
            xlWorkBook = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorksheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            int rw = GetNumberOfRows(xlWorksheet);

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
                //listAccounts.Add(account);
            }

            foreach (Account account in listAccounts)
            {
                MessageBox.Show(account.ToString());
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Marshal.ReleaseComObject(xlWorksheet);
            xlWorkBook.Close();
            Marshal.ReleaseComObject(xlWorkBook);
            //xlWorkBook.Close(true, null, null);
            //xlApp.Quit();
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            return listAccounts;
        }
        //ham write data
        static void Main(string[] args  )
        {
            Excel._Application myExcelApp;
            Excel.Workbooks myExcelWorkbooks;
            Excel.Workbook myExcelWorkbook;
            // Excel ._Worksheet myExccelWorksheetToChange;
            object misValue = System.Reflection.Missing.Value;

            myExcelApp = new Excel.ApplicationClass();
            myExcelApp.Visible = true;
            myExcelWorkbooks = myExcelApp.Workbooks;
            string path = string.Format(@"{0}\data.xlsx", Application.StartupPath);
            String fileName = @path;
            myExcelWorkbook = myExcelWorkbooks.Open(fileName, misValue, misValue, misValue, misValue,
          misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue, misValue);

            Excel.Worksheet myExcelWorksheet = (Excel.Worksheet)myExcelWorkbook.ActiveSheet;

            String cellFormulaAsString = myExcelWorksheet.get_Range("A2", misValue).Formula.ToString();

            myExcelWorksheet.get_Range("A2", misValue).Formula = Console.ReadLine();

        }

    }
}