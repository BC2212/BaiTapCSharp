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
        private string salt;

        //Loại tài khoản: 0-user, 1-admin, 2-sa
            //Sa: tất cả quyền, bao gồm xóa, tạo tài khoản addmin
            //Admin: có thể thêm, sửa, xóa thông tin sinh viên
            //User: chỉ xem hoặc chỉnh sửa thông tin cá nhân
        public byte Type { get; set; }
        //public string Priorities { get; set; }

        private static readonly Random rand = new Random();
        private static readonly SHA512 shaM = new SHA512Managed();

        public Account() {
            Username = "";
            Password = "";
            Type = 0;
            //Tạm thời chưa có cách giải quyết cho priority nên sẽ để sau
            //Priorities = "";
        }

        //Dùng khi user tự tạo account
        public Account(string username, string pre_encryptedPasswd)
        {
            Username = username;
            Password = CreatePassword(pre_encryptedPasswd);
            Type = 0;
        }

        //Dùng khi admin tạo account và phân quyền
        /*public Account(string username, string pre_encryptedPasswd, string priorities, byte type)
        {
            Username = username;
            Password = CreatePassword(pre_encryptedPasswd);
            Type = type;
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

        //Kiểm tra username có tồn tại hay chưa
        private static bool CheckUsername(List<Account> listAccounts, string username)
        {
            return listAccounts.Exists(x => x.Username == username) == true ? true : false;
        }

        //Hàm tìm index của một account
        internal static int SearchIndexOfAccountByUsername(List<Account> listAccounts, string username)
        {
            return listAccounts.FindIndex(delegate (Account account)
            {
                return account.Username.Equals(username);
            });
        }

        //Kiểm tra password có chính xác không nếu chưa tìm ra index của account
        private static bool CheckPassword(List<Account> listAccounts, string username, string passwd)
        {
            int index = SearchIndexOfAccountByUsername(listAccounts, username);

            string encryptedPasswd = EncryptPassword(passwd, listAccounts[index].salt);

            return listAccounts[index].Password.Equals(encryptedPasswd);
        }

        //Kiểm tra password khi đã biết chính xac index của account
        private static bool CheckPassword(List<Account> listAccounts, string passwd, int index)
        {
            string encryptedPasswd = EncryptPassword(passwd, listAccounts[index].salt);

            return listAccounts[index].Password.Equals(encryptedPasswd);
        }

        //Đăng nhập
        public static int LogIn(List<Account> listAccounts, string username, string passwd)
        {
            //Hàm trả về quyền và kết quả kiểm tra dùng để load form phù hợp
            //-1: Đăng nhập thất bại, sai username hoặc mật khẩu
            //0: Là user
            //1: Là admin
            //2: Là sa

            int index = SearchIndexOfAccountByUsername(listAccounts, username);
            Console.WriteLine("index: {0}", index);

            if (index < 0)
                return -1;
            else
            {
                return CheckPassword(listAccounts, passwd, index) ? listAccounts[index].Type : -1;
            }
        }
    }
}
