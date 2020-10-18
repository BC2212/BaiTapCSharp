using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace QLSV.Lib.Data
{
    public class Account
    {
        private static Random rand = new Random();
        private static SHA512 shaM = new SHA512Managed();

        // Cấu trúc của passwd là pass+salt rồi mã hóa
        private static string CreateSalt()
        {
            string salt = "";
            for (int i=0; i<12; i++)
            {

                salt += Convert.ToChar(rand.Next(1, 126)).ToString();
            }
            return salt;
        }

        internal static string CreatePassword(string passwd)
        {
            //Tạo salt
            string salt = CreateSalt();

            //Tạo biến để đem đi encrypt
            var data = Encoding.UTF8.GetBytes(passwd+salt);

            //Trả về passwd đã mã hóa
            return shaM.ComputeHash(data).ToString();
        }
    }
}
