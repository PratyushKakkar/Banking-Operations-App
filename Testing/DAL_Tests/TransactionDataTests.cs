using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Unit_Testing.DAO_Tests
{
     [TestClass]
     public class TransactionDataTests
     {
          private TransactionData? _transactionData;

          [TestInitialize]
          public void Setup()
          {
               string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anku\Desktop\Class Notes\Year 2\OOP\Banking-Operations-App\Banking Operations App\DB.mdf;Integrated Security=True";
               _transactionData = new TransactionData(con);
          }

          [TestMethod]
          public void GetTransactionHistory_ShouldContainMultipleRows()
          {
               // Act
               DataTable result = _transactionData.GetTransactionHistory();

               // Assert
               Assert.IsNotNull(result);
               Assert.IsTrue(result.Rows.Count >= 1, "Expected at least one transaction row.");
          }

          [TestMethod]
          public void GetUserHistory_ShouldReturnRows_ForAccount10000002()
          {
               // Arrange
               int testAccountNumber = 10000002;

               // Act
               DataTable result = _transactionData.GetUserHistory(testAccountNumber);

               // Assert
               Assert.IsNotNull(result);
               Assert.IsTrue(result.Rows.Count >= 1, $"No transaction history found for account {testAccountNumber}.");
          }

          [TestMethod]
          public void UpdateBalance_ShouldExecuteWithoutException()
          {
               // Arrange
               int accountNumber = 10000002;
               decimal newBalance = 2000.00m;

               // Act & Assert
               try
               {
                    _transactionData.updateBalance(accountNumber, newBalance);
                    Assert.IsTrue(true);
               }
               catch (Exception ex)
               {
                    Assert.Fail();
               }
          }

          [TestMethod]
          public void AddTransferRecord_ShouldInsertWithoutException()
          {
               // Act & Assert
               try
               {
                    _transactionData.AddTransferRecord(
                        destinationSortCode: 101010,
                        destinationAccountNum: 10000003,
                        transferAmount: 100.00m,
                        description: "Unit test transfer",
                        transferDateTime: DateTime.Now,
                        sourceAccountID: 10000002
                    );

                    Assert.IsTrue(true);
               }
               catch (Exception ex)
               {
                    Assert.Fail();
               }
          }
     }
}
