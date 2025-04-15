using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Operations_App
{
     //"Client-Side Validation" for the GUI Forms
     public class InputValidation
     {
          //Login Form Username Validation
          public static bool ValidateUsername(string username)
          {
               if (username.All(char.IsLetter))
                    return true;
               else
                    return false;
          }
          //Login Form Password Validation
          public static bool ValidatePassword(string password)
          {
               if (password.Length > 8)
                    return true;
               else
                    return false;
          }

          //Login Button Enabled or Disabled
          public static bool EnableButton(string username, string password)
          {
               if ((ValidateUsername(username) == true) && (ValidatePassword(password) == true))
                    return true;
               else
                    return false;
          }

          //Checks if Username & Password are correct
          public static bool CheckCredentials(string username, string password)
          {
               if (username == "PratyushAdmin" && password == "Password123")
                    return true;
               else
                    return false;
          }

          //Checks if the input is a valid name (First name, Last name, City, etc.)
          public static bool IsValidName(string input)
          {
               return !string.IsNullOrEmpty(input) && input.All(c => char.IsLetter(c) || c == '-' || c == '\'');
          }

          //Checks if the input is a valid email address
          public static bool IsValidEmail(string input)
          {
               return !string.IsNullOrEmpty(input) && input.Contains("@") && input.Contains(".");
          }

          //Checks if the input is a valid phone number
          public static bool IsValidPhone(string input)
          {
               return !string.IsNullOrEmpty(input) && input.All(char.IsDigit) && input.Length == 9;
          }

          //Checks if the input is a valid address, does not contain special characters.
          public static bool IsValidAddress(string input)
          {
               return !string.IsNullOrEmpty(input) &&
                      input.Length >= 3 &&
                      input.Length <= 100 &&
                      input.All(c => char.IsLetterOrDigit(c) || c == ' ' || c == '-' || c == '\'' || c == '.' || c == ',');
          }

          //Checks if the input is a valid account number, 8 digits, only numbers.
          public static bool IsValidAccountNumber(string input)
          {
               return !string.IsNullOrEmpty(input) && input.All(char.IsDigit) && input.Length == 8;
          }

          //Checks if the input is a valid number
          public static bool IsNumericOrDot(string input)
          {
               return !string.IsNullOrEmpty(input) && input.All(c => char.IsDigit(c) || c == '.');
          }

          //Checks if the input is a valid amount, only numbers and dot.
          public static bool IsValidSortCode(string input)
          {
               return !string.IsNullOrEmpty(input) && input.All(char.IsDigit) && input.Length == 6;
          }
     }
}
