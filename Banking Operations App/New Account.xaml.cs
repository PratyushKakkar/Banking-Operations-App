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
using System.Windows.Shapes;
using static Banking_Operations_App.Tables;
using BIZ;

namespace Banking_Operations_App
{
     /// <summary>
     /// Interaction logic for New_Account.xaml
     /// </summary>
     public partial class New_Account : Window
     {
          public New_Account()
          {
               InitializeComponent();
          }

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {
               cboCounty.ItemsSource = Enum.GetValues(typeof(Counties));
               lblLoginValidation.Visibility = Visibility.Collapsed;
          }

          private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_FirstName.Visibility = InputValidation.IsValidName(txtFirstName.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_Surname.Visibility = InputValidation.IsValidName(txtSurname.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_Email.Visibility = InputValidation.IsValidEmail(txtEmail.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_Phone.Visibility = InputValidation.IsValidPhone(txtPhone.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtAddress1_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_Address1.Visibility = InputValidation.IsValidAddress(txtAddress1.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtAddress2_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_Address2.Visibility = InputValidation.IsValidAddress(txtAddress2.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_City.Visibility = InputValidation.IsValidName(txtCity.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void cboCounty_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
               lblInvalidMsg_County.Visibility = cboCounty.SelectedItem != null ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void rdoCurrent_Click(object sender, RoutedEventArgs e)
          {
               lblInvalidMsg_AccType.Visibility =  (rdoCurrent.IsChecked == true || rdoSavings.IsChecked== true) ? Visibility.Collapsed : Visibility.Visible;
               txtOverdraftLimit.IsReadOnly = (rdoCurrent.IsChecked == true) ? false : true;
               btnCreateAccount.IsEnabled = IsFormValid();
          }
          private void rdoSavings_Click(object sender, RoutedEventArgs e)
          {
               lblInvalidMsg_AccType.Visibility = (rdoCurrent.IsChecked == true || rdoSavings.IsChecked == true) ? Visibility.Collapsed : Visibility.Visible;
               txtOverdraftLimit.IsReadOnly = (rdoCurrent.IsChecked == true) ? false : true;
               txtOverdraftLimit.Text = "0.0";
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtAccountNum_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_AccNum.Visibility = InputValidation.IsValidAccountNumber(txtAccountNum.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtInitialBalance_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_IniBal.Visibility = InputValidation.IsNumericOrDot(txtInitialBalance.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private void txtOverdraftLimit_TextInput(object sender, TextCompositionEventArgs e)
          {
               
          }

          private void txtOverdraftLimit_TextChanged(object sender, TextChangedEventArgs e)
          {
               lblInvalidMsg_Overdraft.Visibility = InputValidation.IsNumericOrDot(txtOverdraftLimit.Text) ? Visibility.Collapsed : Visibility.Visible;
               btnCreateAccount.IsEnabled = IsFormValid();
          }

          private bool IsFormValid()
          {
               return InputValidation.IsValidName(txtFirstName.Text) &&
                      InputValidation.IsValidName(txtSurname.Text) &&
                      InputValidation.IsValidEmail(txtEmail.Text) &&
                      InputValidation.IsValidPhone(txtPhone.Text) &&
                      InputValidation.IsValidAddress(txtAddress1.Text) &&
                      InputValidation.IsValidAddress(txtAddress2.Text) &&
                      InputValidation.IsValidName(txtCity.Text) &&
                      cboCounty.SelectedItem != null &&
                      (rdoCurrent.IsChecked == true || rdoSavings.IsChecked == true) &&
                      InputValidation.IsValidAccountNumber(txtAccountNum.Text) &&
                      InputValidation.IsNumericOrDot(txtInitialBalance.Text) &&
                      (rdoCurrent.IsChecked == true ? true : InputValidation.IsNumericOrDot(txtOverdraftLimit.Text));
          }

          private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
          {
               //Inputing Variables
               string firstName = txtFirstName.Text;
               string surname = txtSurname.Text;
               string email = txtEmail.Text;
               string phone = "+353 " + txtPhone.Text;
               string address = txtAddress1.Text + " " + txtAddress2.Text;
               string city = txtCity.Text;
               string county = cboCounty.SelectedItem.ToString();
               string accountType = rdoCurrent.IsChecked == true ? "Current" : "Savings";
               int accountNum = int.Parse(txtAccountNum.Text);
               decimal initialBalance = Decimal.Parse(txtInitialBalance.Text);
               decimal overdraftLimit = rdoCurrent.IsChecked == true ? Decimal.Parse(txtOverdraftLimit.Text) : 0.0m;

               //Creating New Account
               UserAccount na = new UserAccount(firstName, surname, email, phone, address, city, county, accountType, accountNum, initialBalance, overdraftLimit);
               na.addAccount();

               //Display Success Message
               lblLoginValidation.Visibility = Visibility.Visible;

               //Clear Form
               txtFirstName.Text = string.Empty;
               txtSurname.Text = string.Empty;
               txtEmail.Text = string.Empty;
               txtPhone.Text = string.Empty;
               txtAddress1.Text = string.Empty;
               txtAddress2.Text = string.Empty;
               txtCity.Text = string.Empty;
               txtAccountNum.Text = string.Empty;
               txtInitialBalance.Text = string.Empty;
               txtOverdraftLimit.Text = string.Empty;

               cboCounty.SelectedIndex = -1;

               // Hide all validation labels
               lblInvalidMsg_FirstName.Visibility = Visibility.Collapsed;
               lblInvalidMsg_Surname.Visibility = Visibility.Collapsed;
               lblInvalidMsg_Email.Visibility = Visibility.Collapsed;
               lblInvalidMsg_Phone.Visibility = Visibility.Collapsed;
               lblInvalidMsg_Address1.Visibility = Visibility.Collapsed;
               lblInvalidMsg_Address2.Visibility = Visibility.Collapsed;
               lblInvalidMsg_City.Visibility = Visibility.Collapsed;
               lblInvalidMsg_County.Visibility = Visibility.Collapsed;
               lblInvalidMsg_AccType.Visibility = Visibility.Collapsed;
               lblInvalidMsg_AccNum.Visibility = Visibility.Collapsed;
               lblInvalidMsg_IniBal.Visibility = Visibility.Collapsed;
               lblInvalidMsg_Overdraft.Visibility = Visibility.Collapsed;

               //Refresh the DataGrid in MainWindow
               var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
               mainWindow?.RefreshDataGrid();
          }
     }
}
