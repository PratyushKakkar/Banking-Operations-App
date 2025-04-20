using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace Unit_Testing.DAO_Tests
{
     [TestClass]
     public class AccountDataTests
     {
          private AccountData accountData;
          private string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anku\Desktop\Class Notes\Year 2\OOP\Banking-Operations-App\Banking Operations App\DB.mdf;Integrated Security=True";

          [TestInitialize]
          public void Setup()
          {
               accountData = new AccountData(con);
          }

          [TestMethod]
          public void AddAccount_ShouldInsertRecord()
          {
               accountData.addAccount("Tom", "Jones", "tom@jone.ie", "+353894123654", "44 Grafton Way, Wicklow Valley, Ireland.", "Derrwood", "Derry", "Savings", 10000004, 500.0m, 0.0m);

               DataTable result = accountData.PopulateAccountDetails(10000004);

               Assert.IsNotNull(result);
               Assert.AreEqual(1, result.Rows.Count);
          }

          [TestMethod]
          public void PopulateAccNums_ShouldReturnRows()
          {
               DataTable accNums = accountData.PopulateAccNums();

               Assert.IsNotNull(accNums);
               Assert.IsTrue(accNums.Rows.Count > 0);
          }

          [TestMethod]
          public void PopulateAccountDetails_ShouldReturnAccount()
          {
               int knownAccount = 10000000; 

               DataTable details = accountData.PopulateAccountDetails(knownAccount);

               Assert.IsNotNull(details);
               Assert.AreEqual(1, details.Rows.Count);
          }

          [TestMethod]
          public void UpdateAccount_ShouldUpdateDetails()
          {
               int accountNum = 10000004; 

               accountData.updateAccount(accountNum, "updated@mail.com", "9999999999", "New Address", "NewCity", "NewCounty");

               DataTable updated = accountData.PopulateAccountDetails(accountNum);

               Assert.AreEqual("updated@mail.com", updated.Rows[0]["Email"].ToString());
          }
     }
}
