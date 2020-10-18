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
            List<Account> listAccounts = new List<Account>();

            listAccounts.Add(new Account("quynh", "1", 2));
            listAccounts.Add(new Account("minh", "12", 1));
            listAccounts.Add(new Account("linh", "123", 1));
            listAccounts.Add(new Account("nhi", "12345", 0));
            listAccounts.Add(new Account("hieu", "123456", 0));

            Account.PrintAllAccounts(listAccounts);
            System.Console.ReadKey();
        }
    }
}
