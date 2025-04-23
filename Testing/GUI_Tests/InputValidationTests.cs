using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banking_Operations_App;

namespace Testing.GUI_Tests
{

     [TestClass]
     public class InputValidationTests
     {
          [TestMethod]
          public void ValidateUsername_OnlyLetters_ReturnsTrue()
          {
               // Arrange
               string validUsername = "JohnDoe";

               // Act
               bool result = InputValidation.ValidateUsername(validUsername);

               // Assert
               Assert.IsTrue(result);
          }

          [TestMethod]
          public void ValidateUsername_WithNumbers_ReturnsFalse()
          {
               // Arrange
               string invalidUsername = "John123";

               // Act
               bool result = InputValidation.ValidateUsername(invalidUsername);

               // Assert
               Assert.IsFalse(result);
          }

          [TestMethod]
          public void ValidatePassword_MoreThan8Chars_ReturnsTrue()
          {
               // Arrange
               string validPassword = "SecurePass123";

               // Act
               bool result = InputValidation.ValidatePassword(validPassword);

               // Assert
               Assert.IsTrue(result);
          }

          [TestMethod]
          public void ValidatePassword_LessThan8Chars_ReturnsFalse()
          {
               // Arrange
               string invalidPassword = "short";

               // Act
               bool result = InputValidation.ValidatePassword(invalidPassword);

               // Assert
               Assert.IsFalse(result);
          }

          [TestMethod]
          public void EnableButton_ValidCredentials_ReturnsTrue()
          {
               // Arrange
               string validUser = "ValidUser";
               string validPass = "LongPassword";

               // Act
               bool result = InputValidation.EnableButton(validUser, validPass);

               // Assert
               Assert.IsTrue(result);
          }

          [TestMethod]
          public void CheckCredentials_CorrectCredentials_ReturnsTrue()
          {
               // Arrange
               string correctUser = "PratyushAdmin";
               string correctPass = "Password123";

               // Act
               bool result = InputValidation.CheckCredentials(correctUser, correctPass);

               // Assert
               Assert.IsTrue(result);
          }

          [TestMethod]
          public void IsValidName_ValidName_ReturnsTrue()
          {
               // Arrange
               string validName = "O'Connor-Smith";

               // Act
               bool result = InputValidation.IsValidName(validName);

               // Assert
               Assert.IsTrue(result);
          }

          [TestMethod]
          public void IsValidEmail_ValidEmail_ReturnsTrue()
          {
               // Arrange
               string validEmail = "test@example.com";

               // Act
               bool result = InputValidation.IsValidEmail(validEmail);

               // Assert
               Assert.IsTrue(result);
          }

          [TestMethod]
          public void IsValidPhone_ValidPhone_ReturnsTrue()
          {
               // Arrange
               string validPhone = "123456789";

               // Act
               bool result = InputValidation.IsValidPhone(validPhone);

               // Assert
               Assert.IsTrue(result);
          }

          [TestMethod]
          public void IsValidAccountNumber_ValidNumber_ReturnsTrue()
          {
               // Arrange
               string validAccount = "12345678";

               // Act
               bool result = InputValidation.IsValidAccountNumber(validAccount);

               // Assert
               Assert.IsTrue(result);
          }
     }
}
