using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
     public class TransactionData : DAO
     {
          SqlCommand cmd;

          public void updateBalance(int accountNum, decimal balance)
          {
               cmd = OpenCon().CreateCommand();
               cmd.CommandType = CommandType.StoredProcedure;

               cmd.CommandText = "uspUpdateBalance";
               cmd.Parameters.AddWithValue("@AccountNumber", accountNum);
               cmd.Parameters.AddWithValue("@Balance", balance);

               cmd.ExecuteNonQuery();
               CloseCon();
          }

          public void AddTransferRecord(int destinationSortCode, int destinationAccountNum, decimal transferAmount, string description, DateTime transferDateTime, int sourceAccountID)
          {
               cmd = OpenCon().CreateCommand();
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.CommandText = "uspAddTransferRecord";

               cmd.Parameters.AddWithValue("@DestinationSortCode", destinationSortCode);
               cmd.Parameters.AddWithValue("@DestinationAccountNumber", destinationAccountNum);
               cmd.Parameters.AddWithValue("@TransferAmount", transferAmount);
               cmd.Parameters.AddWithValue("@Description", description);
               cmd.Parameters.AddWithValue("@TransferDateTime", transferDateTime);
               cmd.Parameters.AddWithValue("@SourceAccountID", sourceAccountID);

               cmd.ExecuteNonQuery();
               CloseCon();
          }

     }
}
