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
using DAL;
using BIZ;
using System.Data;
using static Banking_Operations_App.Tables;

namespace Banking_Operations_App
{
     /// <summary>
     /// Interaction logic for Edit_Account.xaml
     /// </summary>
     public partial class Edit_Account : Window
     {
          public Edit_Account()
          {
               InitializeComponent();
          }

          DataTable dt;
          AccountData ad = new AccountData();

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {
               dt = ad.PopulateAccNums();
               cboAccountNumber.ItemsSource = dt.DefaultView;
               cboAccountNumber.DisplayMemberPath = "AccountNumber";
               cboAccountNumber.SelectedValuePath = "AccountNumber";

               cboCounty.ItemsSource = Enum.GetValues(typeof(Counties));

               lblUpdateValidation.Visibility = Visibility.Collapsed;
          }

          private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtAddress1_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtAddress2_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtCity_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void rdoCurrent_Click(object sender, RoutedEventArgs e)
          {

          }

          private void rdoSavings_Click(object sender, RoutedEventArgs e)
          {

          }

          private void txtInitialBalance_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtOverdraftLimit_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtOverdraftLimit_TextInput(object sender, TextCompositionEventArgs e)
          {

          }

          private void cboCounty_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {

          }

         

          private void cboAccountNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
               int accountNum = (int)cboAccountNumber.SelectedValue;
               dt = ad.PopulateAccountDetails(accountNum);
               txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
               txtSurname.Text = dt.Rows[0]["Surname"].ToString();
               txtEmail.Text = dt.Rows[0]["Email"].ToString();
               txtPhone.Text = dt.Rows[0]["Phone"].ToString();
               txtAddress.Text = dt.Rows[0]["Address"].ToString();
               txtCity.Text = dt.Rows[0]["City"].ToString();
               cboCounty.SelectedItem = null;
               cboCounty.Text = dt.Rows[0]["County"].ToString();
               if (dt.Rows[0]["AccountType"].ToString() == "Current")
                    rdoCurrent.IsChecked = true;
               else
                    rdoSavings.IsChecked = true;
               txtSortCode.Text = dt.Rows[0]["SortCode"].ToString();
               txtBalance.Text = dt.Rows[0]["Balance"].ToString();
               txtOverdraftLimit.Text = dt.Rows[0]["OverdraftLimit"].ToString();

               btnUpdateAccount.IsEnabled = true;

               lblUpdateValidation.Visibility = Visibility.Collapsed;
          }

          private void btnCreateAccount_Click(object sender, RoutedEventArgs e)
          {
               int accountNum = (int)cboAccountNumber.SelectedValue;
               string email = txtEmail.Text;
               string phone = txtPhone.Text;
               string address = txtAddress.Text;
               string city = txtCity.Text;
               string county = cboCounty.SelectedItem.ToString();

               UserAccount ac = new UserAccount(accountNum, email, phone, address, city, county);
               ac.updateAccount();

               lblUpdateValidation.Visibility = Visibility.Visible;

               txtFirstName.Text = string.Empty;
               txtSurname.Text = string.Empty;
               txtEmail.Text = string.Empty;
               txtPhone.Text = string.Empty;
               txtAddress.Text = string.Empty;
               txtCity.Text = string.Empty;
               txtBalance.Text = string.Empty;
               txtOverdraftLimit.Text = string.Empty;
               cboCounty.SelectedIndex = -1;

               //Refresh MainWindow DataGrid
               var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
               mainWindow?.RefreshDataGrid();

          }
     }
}
