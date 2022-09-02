using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DAL
{
    public class DBService
    {
        public IConfiguration Configuration;
        string connectionString = "";
        public DBService(IConfiguration Configuration)
        {
            connectionString = Configuration.GetConnectionString("DefaultConnection");
        }
        public int ExecuteScalarSet(string ProcedureName, SqlParameter[] Parameters)
        {
            int retVal = -1;
            SqlCommand cmd;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd = new SqlCommand(ProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    CollectParameters(cmd, Parameters);
                    object obj = cmd.ExecuteScalar();
                    if (obj != null)
                    {
                        retVal = Convert.ToInt32(obj.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd = null;
            }
            return retVal;
        }


        //public DataTable ExecuteDataSet(string ProcedureName, SqlParameter[] Parameters)
        //{
        //    System.Data.DataTable ds = new DataTable();

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommand cmd;

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            cmd = new SqlCommand(ProcedureName, conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            CollectParameters(cmd, Parameters);
        //            da.SelectCommand = cmd;
        //            cmd.CommandTimeout = 0;
        //            da.Fill(ds);
        //            CollectOutputParameters(cmd, Parameters);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        cmd = null;
        //    }
        //    return ds;
        //}



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

        //            return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
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

        public static string GetConnectionString()
        {
            try
            {
                string connectionString = "";
                return connectionString;// = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString.ToString();
                //return Encryption.DecryptTripleDES(connectionString);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void CollectParameters(SqlCommand cmd, SqlParameter[] Parameters)
        {
            foreach (SqlParameter p in Parameters)
                cmd.Parameters.Add(p);
        }
        public static void CollectOutputParameters(SqlCommand cmd, SqlParameter[] Parameters)
        {
            foreach (SqlParameter p in Parameters)
            {
                if (p.Direction == ParameterDirection.Output)
                {
                    p.Value = cmd.Parameters[p.ParameterName].Value;
                }
            }
        }

        //public DataSet ExecuteDataSet(string ProcedureName)
        //{
        //    DataSet ds = new DataSet();

        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommand cmd;

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();
        //            cmd = new SqlCommand(ProcedureName, conn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            da.SelectCommand = cmd;
        //            da.Fill(ds);

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //    finally
        //    {
        //        cmd = null;
        //    }
        //    return ds;
        //}

        public string ExecuteScalarValue(string ProcedureName, SqlParameter[] Parameters)
        {

            string strRetVal = string.Empty;
            SqlCommand cmd;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    cmd = new SqlCommand(ProcedureName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    CollectParameters(cmd, Parameters);
                    strRetVal = (string)cmd.ExecuteScalar();
                    CollectOutputParameters(cmd, Parameters);
                }
            }
            catch (SqlException e)
            {
                if (!(e.State == 127 && e.Procedure.StartsWith("TR")))
                    throw e;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd = null;
            }
            return strRetVal;
        }
    }
}