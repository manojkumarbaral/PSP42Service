using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace DAL
{
    public class DataLayer
    {
        public IConfiguration Configuration;
        string connectionString = "";
        public DataLayer()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).
                AddJsonFile("appsettings.json").Build();
            connectionString = builder.GetSection("ConnectionStrings:DefaultConnection").Value;
        }

        public string GetConnectionString()
        {
            try
            {
                return connectionString;
                //return Encryption.EncryptTripleDES(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public class Encryption
        //{
        //    private static byte[] KEY_192 = { 40, 50, 60, 89, 92, 6, 217, 30, 15, 16, 44, 60, 65, 25, 14, 12, 2, 14, 10, 20, 19, 9, 14, 17 };
        //    private static byte[] IV_192 = { 5, 13, 52, 4, 8, 1, 17, 3, 42, 5, 42, 5, 82, 83, 16, 7, 29, 13, 11, 3, 22, 8, 16, 10, 11, 25 };

        //    public static string EncryptTripleDES(string value)
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            TripleDESCryptoServiceProvider CryptoProvider = new TripleDESCryptoServiceProvider();
        //            MemoryStream ms = new MemoryStream();
        //            CryptoStream cs = new CryptoStream(ms, CryptoProvider.CreateEncryptor(KEY_192, IV_192), CryptoStreamMode.Write);
        //            StreamWriter sw = new StreamWriter(cs);

        //            sw.Write(value);
        //            sw.Flush();
        //            cs.FlushFinalBlock();
        //            ms.Flush();
        //            var reuslt = Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
        //            return reuslt;
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }

        //    public static string DecryptTripleDES(string value)
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            TripleDESCryptoServiceProvider CryptoProvider = new TripleDESCryptoServiceProvider();

        //            byte[] buffer = Convert.FromBase64String(value);
        //            MemoryStream ms = new MemoryStream();
        //            CryptoStream cs = new CryptoStream(ms, CryptoProvider.CreateDecryptor(KEY_192, IV_192), CryptoStreamMode.Read);
        //            StreamReader sr = new StreamReader(cs);

        //            return sr.ReadToEnd();
        //        }
        //        else
        //        {
        //            return "";
        //        }
        //    }
        //}
    }
}
