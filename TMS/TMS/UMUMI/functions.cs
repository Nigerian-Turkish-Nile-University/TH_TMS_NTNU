using System;
using System.Collections.Generic;
using System.Text;
using DB;
using System.Security.Cryptography;
namespace General
{
    class functions
    {
        DB.oraConn con = oraConn.DB;
        static private System.Collections.Hashtable _CfgActValArray = new System.Collections.Hashtable(); 
        /*
        public string GetMD5Hash(string input)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            string password = s.ToString();
            return password;
        }*/

        public static string getMd5Hash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    
        public int[] GetCfgActVal(string nm)
        {
            if (_CfgActValArray.Count == 0) LoadCfgActVals();
            return ((int[])_CfgActValArray[nm]);
        }

        private void LoadCfgActVals()
        {
            try
            {
                Oracle.DataAccess.Client.OracleDataReader odr = con.execSQL("select t.cfg_key, t.term, t.year  from dbmaster.cfg_active_period t");
                while (odr.Read())
                {
                    _CfgActValArray[odr["cfg_key"].ToString()] = new int[] { Convert.ToInt32(odr["year"]), Convert.ToInt16(odr["term"]) };
                }
                odr.Close();
            }
            catch (Exception) { }
        }

        public string getCiCu(string sayi)
        {
            try
            {
                string s = sayi.Substring(sayi.Length-1, 1);
                if (s == "0") s = sayi.Substring(sayi.Length-2, 2);             
                if (s != "")
                {
                    switch (Convert.ToInt16(s))
                    {
                        case 1: return "ci";
                        case 2: return "ci";
                        case 3: return "cü";
                        case 4: return "cü";
                        case 5: return "ci";
                        case 6: return "cı";
                        case 7: return "ci";
                        case 8: return "ci";
                        case 9: return "cu";
                        case 10: return "cu";
                        case 20: return "ci";
                        case 30: return "cu";
                        case 40: return "cı";
                        case 50: return "ci";
                        case 60: return "cı";
                        case 70: return "ci";
                        case 80: return "ci";
                        case 90: return "cı";
                        default: return "";
                    }
                }
                else return "";
            }
            catch (Exception) 
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message,);
                return ""; 
            }
        }
    }
}
