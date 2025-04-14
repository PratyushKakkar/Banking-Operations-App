using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BIZ;
using DAL;

namespace Banking_Operations_App
{
     /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
     public partial class MainWindow : Window
     {
          public MainWindow()
          {
               InitializeComponent();
          }

          private void btnForgotPassword_Click(object sender, RoutedEventArgs e)
          {
              Under_Construction uc = new Under_Construction();
               uc.Show();
          }

          private void btnLogin_Click(object sender, RoutedEventArgs e)
          {
               //Input Username and Password
               string username = txtUsername.Text;
               string password = txtPassword.Password;


               //Validate
               if (InputValidation.CheckCredentials(username, password))
               {
                    lblLoginValidation.Content = "Successful Login!";
                    lblLoginValidation.Foreground = Brushes.Green;
                    btnLogin.IsEnabled = false;
                    txtUsername.IsEnabled = false;
                    txtPassword.IsEnabled = false;
                    txtUsername.Background = Brushes.LightGray;
                    txtPassword.Background = Brushes.LightGray;

                    //Menu Item Account visible when logged in
                    mnuAccount.Visibility = Visibility.Visible;
               }

               else
               {
                    lblLoginValidation.Content = "Incorrect Credentials!";
                    txtUsername.Clear();
                    txtPassword.Clear();
               }
          }

          //Login Form Username Validation   
          private void txtUsername_TextChanged(object sender, TextChangedEventArgs e)
          {
               string username = txtUsername.Text;

               if (InputValidation.ValidateUsername(username) == false)
                    txtUsernameValidation.Content = "Only Letters Allowed!";
               else
               {
                    txtUsernameValidation.Content = "";
                    btnLogin.IsEnabled = InputValidation.EnableButton(username, txtPassword.Password);
               }
          }

          //Login Form Password Validation
          private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
          {
               string password = txtPassword.Password.ToString();
               if (InputValidation.ValidatePassword(password) == false)
                    txtPasswordValidation.Content = "Must be 8 char long!";
               else
               {
                    txtPasswordValidation.Content = "";
                    btnLogin.IsEnabled = InputValidation.EnableButton(txtUsername.Text, password);
               }
          }

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {
               //Login Button Disabled until Valid Credentials are entered
               btnLogin.IsEnabled = false;
               mnuAccount.Visibility = Visibility.Hidden; 
          }

          private void mnuExit_Click(object sender, RoutedEventArgs e)
          {
               // Close the application
               Application.Current.Shutdown();
          }

          //Open New Account Window
          private void mnuNewAccount_Click(object sender, RoutedEventArgs e)
          {
              New_Account na = new New_Account();
               na.Show();
          }
     }
}
