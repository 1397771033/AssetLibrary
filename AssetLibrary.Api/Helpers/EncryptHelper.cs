using System;
using System.Security.Cryptography;
using System.Text;

namespace AssetLibrary.Api.Helpers
{
    public static class EncryptHelper
    {
        public static string MD5Encrypt32(string str)
        {
            string cl = str;
            string encryptStr = "";
            MD5 md5 = MD5.Create(); 
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
            for (int i = 0; i < s.Length; i++)
            {
                encryptStr = encryptStr + s[i].ToString("X");
            }
            return encryptStr;
        }
        public static string MD5Encrypt16(string str)
        {
            var md5 = new MD5CryptoServiceProvider();
            string encryptStr = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(str)), 4, 8);
            encryptStr = encryptStr.Replace("-", "");
            return encryptStr;
        }
    }
}
