using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLSV.Lib;

namespace QLSV.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGetAccountFromExcel();

            System.Console.ReadKey();
        }

        public static void TestGetAccountFromExcel()
        {
            List<Account> listAccounts = Data.GetDataFromExcel(@"D:\BCat22\DoAnCSharp\QLSV.Console\bin\Debug\dataAccount.xlsx");

            Account.PrintAllAccounts(listAccounts);
        }
    }
}