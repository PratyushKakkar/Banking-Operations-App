using BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing.BIZ_Tests
{
     [TestClass]
     public class TransferTests
     {
          string con;

          [TestInitialize]
          public void Setup()
          {
                con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anku\Desktop\Class Notes\Year 2\OOP\Banking-Operations-App\Banking Operations App\DB.mdf;Integrated Security=True";
          }

          [TestMethod]
          public void TransferFunds_WithSufficientBalance_ShouldSucceed()
          {
               // Arrange
               int sourceAccountId = 10000000;
               int destinationAccountNum = 10000001;
               decimal transferAmount = 50.00m;
               int sortCode = 101010;

               Transfer transfer = new Transfer(
                   con,
                   destinationSortCode: sortCode,
                   destinationAccountNum: destinationAccountNum,
                   transferAmount: transferAmount,
                   description: "Test Transfer",
                   sourceAccountID: sourceAccountId
               );

               // Act
               bool result = transfer.TransferFunds();

               // Assert
               Assert.IsTrue(result, "Transfer should succeed with sufficient funds.");
          }

          [TestMethod]
          public void TransferFunds_WithInsufficientBalance_ShouldFail()
          {
               // Arrange
               int sourceAccountId = 10000000;
               int destinationAccountNum = 10000001;
               decimal excessiveAmount = 1000000.00m; // Unrealistically high to simulate failure
               int sortCode = 101010;

               Transfer transfer = new Transfer(
                    con,
                   destinationSortCode: sortCode,
                   destinationAccountNum: destinationAccountNum,
                   transferAmount: excessiveAmount,
                   description: "Excessive Transfer",
                   sourceAccountID: sourceAccountId
               );

               // Act
               bool result = transfer.TransferFunds();

               // Assert
               Assert.IsFalse(result, "Transfer should fail due to insufficient funds.");
          }

          [TestMethod]
          public void TransferFunds_WithNegativeAmount_ShouldFail()
          {
               // Arrange
               int sourceAccountId = 10000000;
               int destinationAccountNum = 10000001;
               decimal negativeAmount = -500.00m;
               int sortCode = 101010;

               Transfer transfer = new Transfer(
                    con,
                   destinationSortCode: sortCode,
                   destinationAccountNum: destinationAccountNum,
                   transferAmount: negativeAmount,
                   description: "Negative Transfer",
                   sourceAccountID: sourceAccountId
               );

               // Act
               bool result = transfer.TransferFunds();

               // Assert
               Assert.IsFalse(result, "Transfer should fail with a negative amount.");
          }
     }
}
