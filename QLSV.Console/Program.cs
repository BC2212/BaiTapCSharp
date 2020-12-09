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

            listAccounts.Add(new Account("quynh", 2, 15));
            listAccounts.Add(new Account("minh", 1, 1));
            listAccounts.Add(new Account("linh", 1, 1));
            listAccounts.Add(new Account("nam", 0, 1));
            listAccounts.Add(new Account("hieu", 0, 1));

            switch (Account.LogIn(listAccounts, "quynh", "12345678"))
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

            System.Console.WriteLine(listAccounts[0].CheckPermission(Permissions.Special));
            System.Console.ReadKey();
        }
    }
}