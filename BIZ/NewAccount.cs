using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BIZ
{
     public class NewAccount
     {

          AccountData ad = new AccountData();

          public string FirstName { get; set; }
          public string Surname { get; set; }
          public string Email { get; set; }
          public string Phone { get; set; }
          public string Address { get; set; }
          public string City { get; set; }
          public string County { get; set; }
          public string AccountType { get; set; }
          public int AccountNum { get; set; }
          public decimal InitialBalance { get; set; }
          public decimal OverdraftLimit { get; set; }

          //Constructor
          public NewAccount(string firstName, string surname, string email, string phone, string address, string city, string county, string accountType, int accountNum, decimal initialBalance, decimal overdraftLimit)
          {
               FirstName = firstName;
               Surname = surname;
               Email = email;
               Phone = phone;
               Address = address;
               City = city;
               County = county;
               AccountType = accountType;
               AccountNum = accountNum;
               InitialBalance = initialBalance;
               OverdraftLimit = overdraftLimit;
          }

          public NewAccount(int accountNum, string email, string phone, string address, string city, string county)
          {
               AccountNum = accountNum;
               Email = email;
               Phone = phone;
               Address = address;
               City = city;
               County = county;
          }

          //Method to create a new account
          public void addAccount()
          {
               ad.addAccount(FirstName, Surname, Email, Phone, Address, City, County, AccountType, AccountNum, InitialBalance, OverdraftLimit);
          }

          public void updateAccount()
          {
               ad.updateAccount(AccountNum, Email, Phone, Address, City, County);
          }
     }
}
