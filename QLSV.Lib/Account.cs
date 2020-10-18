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
        public string Username { get; set; }
        public string Password { get; set; }
        //public string Priorities { get; set; }

        private static Random rand = new Random();
        private static SHA512 shaM = new SHA512Managed();

        public Account() {
            Username = "";
            Password = "";
            //Tạm thời chưa có cách giải quyết cho priority nên sẽ để sau
            //Priorities = "";
        }

        //Dùng khi user tự tạo account
        public Account(string username, string pre_encryptedPasswd)
        {
            Username = username;
            Password = CreatePassword(pre_encryptedPasswd);
        }

        //Dùng khi admin tạo account và phân quyền
        /*public Account(string username, string pre_encryptedPasswd, string priorities)
        {
            Username = username;
            Password = CreatePassword(pre_encryptedPasswd);
            Priorities = priorities;
        }*/

        //Cấu trúc của passwd là pass+salt rồi mã hóa
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
            //Mã hóa thành dãy các số
            byte[] data = shaM.ComputeHash(Encoding.UTF8.GetBytes(pre_encryptedPasswd + salt));

            //Chuyển các số đó thành string và gộp lại
            string encryptedPasswd = "";

            for (int i = 0; i < data.Length; i++)
                encryptedPasswd += data[i].ToString();

            return encryptedPasswd;
        }

        //Tạo password
        internal static string CreatePassword(string passwd)
        {
            //Tạo salt
            string salt = CreateSalt();

            //Trả về passwd đã mã hóa qua hàm mã hóa
            return EncryptPassword(passwd, salt);
        }

        //Hàm đổi password. Không phải là hàm static nên có thể gọi trực tiếp từ object
        public string ChangePassword(string passwd)
        {
            string salt = CreateSalt();

            return EncryptPassword(passwd, salt);
        }
    }
}
