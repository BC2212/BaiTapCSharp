using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Lib;
using System.Globalization;

namespace QLSV.Console
{
    class Program
    {
        public static string sysDateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

        static void Main(string[] args)
        {
            //TestGetAccountFromExcel();
            //TestGetSinhVienFromExcel();

            System.Console.ReadKey();
        }

        public static void TestGetAccountFromExcel()
        {
            List<Account> listAccounts = Data.GetAccountsFromExcel(@"D:\BCat22\DoAnCSharp\QLSV.Console\bin\Debug\dataAccount.xlsx");

            Account.PrintAllAccounts(listAccounts);
        }

        public static void TestGetSinhVienFromExcel()
        {
            List<SinhVien> listSinhViens = Data.GetSinhViensFromExcel(@"D:\BCat22\DoAnCSharp\QLSV.Console\bin\Debug\dataSinhVien.xlsx");

            SinhVien.PrintAllSinhVien(listSinhViens);
        }
    }
}