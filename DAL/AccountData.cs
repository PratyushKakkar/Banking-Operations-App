using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
     public class AccountData : DAO
     {

          SqlCommand cmd;
          SqlDataAdapter da;
          DataTable dt;

          public void addAccount(string firstName, string surname, string email, string phone, string address, string city, string county, string accountType, int accountNum, decimal initialBalance, decimal overdraftLimit)
          {
               cmd = OpenCon().CreateCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "uspAddAccount";

               cmd.Parameters.AddWithValue("@FirstName", firstName);
               cmd.Parameters.AddWithValue("@Surname", surname);
               cmd.Parameters.AddWithValue("@Email", email);
               cmd.Parameters.AddWithValue("@Phone", phone);
               cmd.Parameters.AddWithValue("@Address", address);
               cmd.Parameters.AddWithValue("@City", city);
               cmd.Parameters.AddWithValue("@County", county);
               cmd.Parameters.AddWithValue("@AccountType", accountType);
               cmd.Parameters.AddWithValue("@AccountNumber", accountNum);
               cmd.Parameters.AddWithValue("@Balance", initialBalance);
               cmd.Parameters.AddWithValue("@OverdraftLimit", overdraftLimit);

               cmd.ExecuteNonQuery();
               CloseCon();
          }


          public DataTable PopulateAccNums()
          {
               da = new SqlDataAdapter();
               dt = new DataTable();

               cmd = OpenCon().CreateCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "uspGetAccNums";

               da.SelectCommand = cmd;
               da.Fill(dt);

               return dt;
          }

          public DataTable PopulateAccountDetails(int accountNum)
          {
               da = new SqlDataAdapter();
               dt = new DataTable();

               cmd = OpenCon().CreateCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "uspGetAccDetails";

               cmd.Parameters.AddWithValue("@AccountNumber", accountNum);
               da.SelectCommand = cmd;

               da.Fill(dt);

               return dt;
          }

          public void updateAccount(int accountNum, string email, string phone, string address, string city, string county)
          {
               cmd = OpenCon().CreateCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "uspUpdateAccDetails";

               cmd.Parameters.AddWithValue("@AccountNumber", accountNum);
               cmd.Parameters.AddWithValue("@Email", email);
               cmd.Parameters.AddWithValue("@Phone", phone);
               cmd.Parameters.AddWithValue("@Address", address);
               cmd.Parameters.AddWithValue("@City", city);
               cmd.Parameters.AddWithValue("@County", county);

               cmd.ExecuteNonQuery();
               CloseCon();
          }
     }
}
