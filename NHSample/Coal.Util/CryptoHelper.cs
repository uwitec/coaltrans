using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;
using System.Security.Cryptography;

namespace Coal.Util
{
    public class CryptoHelper
    {
        public static string Encrypt(string original, string key)
        {
            TripleDESCryptoServiceProvider DESProvider = new TripleDESCryptoServiceProvider();
            byte[] org_bytes = Encoding.UTF8.GetBytes(original);
            byte[] key_bytes = Encoding.UTF8.GetBytes(key);

            DESProvider.Key = makeMD5(key_bytes);
            DESProvider.Mode = CipherMode.ECB;
            byte[] target = DESProvider.CreateEncryptor().TransformFinalBlock(org_bytes, 0, org_bytes.Length);
            DESProvider.Clear();
            return Convert.ToBase64String(target);
        }

        public static string Decrypt(string encrypted, string key)
        {
            TripleDESCryptoServiceProvider DESProvider = new TripleDESCryptoServiceProvider();
            try
            {
                byte[] encry_bytes = Convert.FromBase64String(encrypted);
                byte[] key_bytes = Encoding.UTF8.GetBytes(key);
                DESProvider.Key = makeMD5(key_bytes);
                DESProvider.Mode = CipherMode.ECB;
                byte[] source = DESProvider.CreateDecryptor().TransformFinalBlock(encry_bytes, 0, encry_bytes.Length);
                DESProvider.Clear();
                return Encoding.UTF8.GetString(source);
            }
            catch(Exception ex)
            {
                LogWriter.WriteErrLog(ex.Message + "\r\n" + ex.StackTrace);
                return string.Empty;
            }
            finally
            {
                DESProvider.Clear();
            }
        }

        public static string MakeMD5(string key)
        {
            return Convert.ToBase64String(makeMD5(Encoding.UTF8.GetBytes(key)));
        }

        public static string MakeMD5(params string[] strArray)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string item in strArray) sb.Append(item);
            return MakeMD5(sb.ToString());
        }

        private static byte[] makeMD5(byte[] key)
        {
            MD5CryptoServiceProvider MD5Provider = new MD5CryptoServiceProvider();
            byte[] keyhash = MD5Provider.ComputeHash(key);
            MD5Provider.Clear();
            return keyhash;
        }

    }
}
