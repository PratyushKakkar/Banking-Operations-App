using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
     public class UserTransactions
     {
          public int AccountNum { get; set; }
          public decimal Balance { get; set; }
          public decimal OverdraftLimit { get; set; }
          public decimal Amount { get; set; }

          TransactionData td = new TransactionData();

          public UserTransactions(int accountNum, decimal balance, decimal overdraftLimit, decimal amount)
          {
               AccountNum = accountNum;
               Balance = balance;
               OverdraftLimit = overdraftLimit;
               Amount = amount;
          }

          public bool Deposit()
          {
               if (Amount > 0)
               {
                    Balance += Amount;
                    td.updateBalance(AccountNum, Balance);
                    return true; // Deposit successful
               }
               else
                    return false; // Invalid deposit amount
          }

          public bool Withdraw()
          {
               if ((Balance + OverdraftLimit) < Amount && Amount > 0)
               {
                    return false; // Insufficient funds
               }
               else
               {
                    Balance -= Amount;
                    td.updateBalance(AccountNum, Balance);
                    return true; // Withdrawal successful
               }
          }
     }


}
