using BIZ;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.BIZ_Tests
{
     [TestClass]
     public class UserAccountTests
     {
          string con;

          [TestInitialize]
          public void Setup()
          {
                con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anku\Desktop\Class Notes\Year 2\OOP\Banking-Operations-App\Banking Operations App\DB.mdf;Integrated Security=True";
          }

          [TestMethod]
          public void AddAccount_ShouldInsertAccountIntoDatabase()
          {
               // Arrange
               int testAccountNum = 12345678;
               UserAccount user = new UserAccount(
                   con,
                   "Test",
                   "User",
                   "testuser@example.com",
                   "1234567890",
                   "123 Test Street",
                   "TestCity",
                   "TestCounty",
                   "Current",
                   testAccountNum,
                   1000.00m,
                   200.00m
               );

               try
               {
                    // Act
                    user.addAccount();
               }
               catch (Exception ex)
               {
                    Assert.Fail("Exception thrown: " + ex.Message);
               }
          }

          [TestMethod]
          public void UpdateAccount_ShouldModifyAccountDetailsInDatabase()
          {
               //Arrange
               int testAccountNum = 12345678;
               string updatedEmail = "updateduser@example.com";
               string updatedPhone = "9999999999";
               string updatedAddress = "456 Updated Street";
               string updatedCity = "UpdatedCity";
               string updatedCounty = "UpdatedCounty";

               UserAccount user = new UserAccount(
                   con,
                   testAccountNum,
                   updatedEmail,
                   updatedPhone,
                   updatedAddress,
                   updatedCity,
                   updatedCounty
               );

               try
               {
                    // Act
                    user.updateAccount();
               }
               catch (Exception ex)
               {
                    Assert.Fail("Exception thrown: " + ex.Message);
               }
          }
     }
}
