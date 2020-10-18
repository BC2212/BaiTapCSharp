using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace QLSV.Lib
{
    public class Account
    {
        private static Random rand = new Random();
        private static SHA512 shaM = new SHA512Managed();

        // Cấu trúc của passwd là pass+salt rồi mã hóa
        private static string CreateSalt()
        {
            int i = 0;
            string salt = "";

            while (i < 12)
            {
                var randNum = rand.Next(46, 122);

                if ((randNum >= 48 && randNum <=57) || (randNum>=65 && randNum <= 90) || (randNum >=97 && randNum <= 122))
                {
                    salt += Convert.ToChar(randNum);
                    i++;
                }
            }
            return salt;
        }

        //Hàm mã hóa password dùng SHA512
        internal static string EncryptPassword(string pre_encryptedPasswd, string salt)
        {
            byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(pre_encryptedPasswd + salt));
            string encryptedPasswd = "";

            for (int i = 0; i < data.Length; i++)
                encryptedPasswd += data[i].ToString();

            return encryptedPasswd;
        }

        internal static string CreatePassword(string passwd)
        {
            //Tạo salt
            string salt = CreateSalt();

            //Trả về passwd đã mã hóa
            return EncryptPassword(passwd, salt);
        }
    }
}
