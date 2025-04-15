using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;


namespace BIZ
{
     public class Transfer
     {
          public int DestinationSortCode { get; set; }
          public int DestinationAccountNum { get; set; }
          public decimal TransferAmount { get; set; }
          public string Description { get; set; }
          public DateTime TransferDateTime { get; set; }
          public int SourceAccountID { get; set; }

          //Properties to recieve from DAO
          public decimal Balance { get; set; }
          public decimal OverdraftLimit { get; set; }

          public Transfer(int destinationSortCode, int destinationAccountNum, decimal transferAmount, string description, int sourceAccountID)
          {
               DestinationSortCode = destinationSortCode;
               DestinationAccountNum = destinationAccountNum;
               TransferAmount = transferAmount;
               Description = description;
               TransferDateTime = DateTime.Now;
               SourceAccountID = sourceAccountID;
          }

          public bool TransferFunds()
          {
               DataTable dt;

               //Retrieve Source Account Details
               AccountData ad = new AccountData();
               dt = ad.PopulateAccountDetails(SourceAccountID);
               Balance = decimal.Parse(dt.Rows[0]["Balance"].ToString());
               OverdraftLimit = decimal.Parse(dt.Rows[0]["OverdraftLimit"].ToString());

               //Check if sufficient funds are available
               TransactionData td = new TransactionData();
                if((Balance + OverdraftLimit) < TransferAmount && TransferAmount > 0)
                    return false; // Insufficient funds
               else
               {
                    Balance -= TransferAmount;
                    td.updateBalance(SourceAccountID, Balance);
               }    //Sufficient funds, deduct from source account

               //Add to Destination Account
               if(DestinationSortCode == 101010)
               {
                    //Retrieve Destination Account Details
                    dt = ad.PopulateAccountDetails(DestinationAccountNum);
                    Balance = decimal.Parse(dt.Rows[0]["Balance"].ToString());
                    OverdraftLimit = decimal.Parse(dt.Rows[0]["OverdraftLimit"].ToString());

                    //Update Balance
                    Balance += TransferAmount;
                    td.updateBalance(DestinationAccountNum, Balance);
               }

               //Create Transaction Record
               td.AddTransferRecord(DestinationSortCode, DestinationAccountNum, TransferAmount, Description, TransferDateTime, SourceAccountID);

               return true; // Transfer successful
          }
     }
}
