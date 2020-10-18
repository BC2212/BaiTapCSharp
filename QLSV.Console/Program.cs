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

            switch(Account.LogIn(listAccounts, "quynh", "1"))
            {
                case 0:
                    System.Console.WriteLine("Day la tai khoan cua mot user");
                    break;
                case 1:
                    System.Console.WriteLine("Day la tai khoan cua mot admin");
                    break;
                case 2:
                    System.Console.WriteLine("Day la tai khoan cua mot system admin");
                    break;
                default:
                    System.Console.WriteLine("Sai tai khoan hoac mat khau");
                    break;
            }
            System.Console.ReadKey();
        }
    }
}
