using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loop_Inventory
{
    public class ModCommonClasses
    {
        public static SqlConnection con = null;
        public static SqlCommand cmd;
        public static SqlCommand cmd1;
        public static SqlDataReader rdr = null;
        public static SqlDataAdapter adp;
        public static SqlCommand cmd2;
        public static SqlCommand cmd3;
        public static SqlCommand cmd4;
        public static SqlCommand cmd5;
        public static SqlCommand cmd6;
        public static SqlCommand cmd7;
        public static SqlCommand cmd8;


        public static DataSet ds;
        
        public static DataTable dtable;
    }
}
