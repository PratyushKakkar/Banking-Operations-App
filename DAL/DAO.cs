using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

//Data Access Layer
namespace DAL
{

     //Data Access Object
    public class DAO
    {
          SqlConnection con;

          public DAO()
          {
               con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString);
          }

          public SqlConnection OpenCon()
          {
               if (con.State == ConnectionState.Broken || con.State == ConnectionState.Closed)
               {
                    con.Open();
               }
               return con;
          }

          public void CloseCon()
          {
               if (con != null)
               {
                    if (con.State == ConnectionState.Open)
                    {
                         con.Close();
                    }
               }
          }
     }
}
