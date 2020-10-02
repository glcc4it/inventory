using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace Loop_Inventory
{
    public class ModFunc
    {

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static void SMS(string st1)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into SMS(Message,Date) VALUES (@d1,@d2)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", st1);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", DateTime.Now);
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }
        public static void LogFunc(string st1, string st2)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into Logs(UserID,Date,Operation) VALUES (@d1,@d2,@d3)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", st1);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", DateTime.Now);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", st2);
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }
        public static void SMSFunc(string st1, string st2, string st3)
        {
            st3 = st3.Replace("@MobileNo", st1).Replace("@Message", st2);
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Uri myUri = new Uri(st3);
            request = (HttpWebRequest)WebRequest.Create(myUri);
            response = (HttpWebResponse)request.GetResponse();
        }
        public static string Encrypt(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }


        public static void LedgerDelete(string a, string b)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cq = "delete from LedgerBooks where LedgerNo=@d1 and Label=@d2";
            ModCommonClasses.cmd = new SqlCommand(cq);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }



        public static void SupplierLedgerDelete(string a)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cq = "delete from SupplierLedgerBook where LedgerNo=@d1";
            ModCommonClasses.cmd = new SqlCommand(cq);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }




        public static void SupplierInvoiceDelete(string a)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cq = "delete from SupplierLedgerBook where LedgerNo=@d1";
            ModCommonClasses.cmd = new SqlCommand(cq);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }




        public static void CustomerLedgerDelete(string a)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cq = "delete from CustomerLedgerBook where LedgerNo=@d1";
            ModCommonClasses.cmd = new SqlCommand(cq);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }



        public static void CustomerInvoiceDelete(string a)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cq = "delete from CustomerLedgerBook where Invoiceno=@d1";
            ModCommonClasses.cmd = new SqlCommand(cq);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }





        public static void tempstockDelete(string a)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cq = "delete from Temp_Stock where Productcode=@d1";
            ModCommonClasses.cmd = new SqlCommand(cq);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }


        public static void SupplierLedgerSave(string a, string b, string c, string d, decimal e, decimal f, string g)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into SupplierLedgerBook(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);
         
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();


           

        }



        
        
        
        
        
        
        
        
        public static void LedgerSave(string a, string b, string c, string d, decimal e, decimal f, string g)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into LedgerBooks(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);

            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }





        public static void ServicesLedgerBook(string a, string b, string c, string d, decimal e, decimal f, string g)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into ServicesLedgerBook(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);

            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }


        
        
        
        
        
        public static void LedgerUpdate(DateTime a, string b, decimal e, decimal f, string g, string h, string i)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "Update LedgerBooks set Date=@d1, Name=@d2,Debit=@d3,Credit=@d4,Mobileno=@d5 where LedgerNo=@d6 and Label=@d7";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", g);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", h);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", i);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }




        
        
        
        
        
        
        
        public static void SupplierLedgerSaveInvoice(string a, string b, string c, string d, decimal e, decimal f, string g)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into SupplierLedgerBook(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);

            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }







        public static void LedgerSaveInvoice(string a, string b, string c, string d, decimal e, decimal f, string g)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into LedgerBooks(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);

            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public static void CustomerLedgerSave(string a, string b, string c, string d, decimal e, decimal f, string g)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into CustomerLedgerBook(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }






        public static void CustomerLedgerSaveInvoice(DateTime a, string b, string c, string d, decimal e, decimal f, string g, string h)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into CustomerLedgerBook(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno,Invoiceno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7,@d8)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d8", h);
            
            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }






        public static string Decrypt(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new string(decoded_char);
            return decryptpwd;
        }

        public static void CustomerLedgerSaveInvoice(string a, string b, string c, string d, decimal e, decimal f, string g)
        {
            ModCommonClasses.con = new SqlConnection(ModCS.cs);
            ModCommonClasses.con.Open();
            string cb = "insert into CustomerLedgerBook(Date, LedgerNo, Name, Label,Debit,Credit,Mobileno) Values (@d1,@d2,@d3,@d4,@d5,@d6,@d7)";
            ModCommonClasses.cmd = new SqlCommand(cb);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d1", a);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d2", b);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d3", c);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d4", d);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d5", e);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d6", f);
            ModCommonClasses.cmd.Parameters.AddWithValue("@d7", g);

            ModCommonClasses.cmd.Connection = ModCommonClasses.con;
            ModCommonClasses.cmd.ExecuteReader();
            ModCommonClasses.con.Close();
        }
    }


}