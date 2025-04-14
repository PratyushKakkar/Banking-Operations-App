using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
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
	 }
}
