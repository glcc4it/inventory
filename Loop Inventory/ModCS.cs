using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loop_Inventory
{
    public class ModCS
    {
        private static string st;
        public static string InvoiceNumber;

        public static string Accounttype;

        
        
        
        public static string ReadCS()
        {
            using (StreamReader sr = new StreamReader(Application.StartupPath + "\\SQLSettings.dat"))
            {
                st = sr.ReadLine();
            }
            return st;
        }
        public static readonly string cs = ReadCS();
    }
}
