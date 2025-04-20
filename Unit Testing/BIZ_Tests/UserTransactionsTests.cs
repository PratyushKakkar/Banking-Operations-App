using BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing.DAL_Tests
{
     [TestClass]
     public class UserTransactionsTests
     {
          string con;
          [TestInitialize]
          public void Setup()
          {
                con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anku\Desktop\Class Notes\Year 2\OOP\Banking-Operations-App\Banking Operations App\DB.mdf;Integrated Security=True";
          }

          [TestMethod]
          public void Deposit_PositiveAmount_ShouldIncreaseBalance()
          {
               // Arrange
               decimal startingBalance = 1000;
               decimal depositAmount = 500;
               UserTransactions ut = new UserTransactions(con, 123456, startingBalance, 0, depositAmount);

               // Act
               bool result = ut.Deposit();

               // Assert
               Assert.IsTrue(result);
               Assert.AreEqual(1500, ut.Balance);
          }

          [TestMethod]
          public void Deposit_ZeroOrNegativeAmount_ShouldReturnFalse()
          {
               // Arrange
               UserTransactions ut = new UserTransactions(con, 123456, 1000, 0, -200);

               // Act
               bool result = ut.Deposit();

               // Assert
               Assert.IsFalse(result);
               Assert.AreEqual(1000, ut.Balance); // Balance should remain unchanged
          }

          [TestMethod]
          public void Withdraw_ValidAmountWithinBalance_ShouldSucceed()
          {
               // Arrange
               UserTransactions ut = new UserTransactions(con, 123456, 1000, 200, 300);

               // Act
               bool result = ut.Withdraw();

               // Assert
               Assert.IsTrue(result);
               Assert.AreEqual(700, ut.Balance);
          }

          [TestMethod]
          public void Withdraw_AmountExceedsBalanceAndOverdraft_ShouldFail()
          {
               // Arrange
               UserTransactions ut = new UserTransactions(con, 123456, 500, 100, 700); // Total available: 600

               // Act
               bool result = ut.Withdraw();

               // Assert
               Assert.IsFalse(result);
               Assert.AreEqual(500, ut.Balance); // Balance should not change
          }

          [TestMethod]
          public void Withdraw_ZeroOrNegativeAmount_ShouldFail()
          {
               // Arrange
               UserTransactions ut = new UserTransactions(con, 123456, 500, 100, -50);

               // Act
               bool result = ut.Withdraw();

               // Assert
               Assert.IsFalse(result);
               Assert.AreEqual(500, ut.Balance);
          }
     }
}
