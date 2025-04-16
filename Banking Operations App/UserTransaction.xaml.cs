using System;
using System.Collections.Generic;
using System.Data;
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

namespace Banking_Operations_App
{
     /// <summary>
     /// Interaction logic for UserTransaction.xaml
     /// </summary>
     public partial class UserTransaction : Window
     {
          public UserTransaction()
          {
               InitializeComponent();
          }
          DataTable dt;
          AccountData ad = new AccountData();

          decimal balance, overdraftLimit;

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {
               dt = ad.PopulateAccNums();
               cboAccountNumber.ItemsSource = dt.DefaultView;
               cboAccountNumber.DisplayMemberPath = "AccountNumber";
               cboAccountNumber.SelectedValuePath = "AccountNumber";
          }

          private void cboAccountNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
               PopulateDetails();
          }



          private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
          {

          }

          private void txtAmount_TextChanged(object sender, TextChangedEventArgs e)
          {
               btnSubmit.IsEnabled = (!string.IsNullOrEmpty(txtAmount.Text) && cboAccountNumber.SelectedIndex != -1);

          }

          private void btnSubmit_Click(object sender, RoutedEventArgs e)
          {
               decimal amount = decimal.Parse(txtAmount.Text);
               int accountNum = (int)cboAccountNumber.SelectedValue;

               UserTransactions ut = new UserTransactions(accountNum, balance, overdraftLimit, amount);

               lblUpdateValidation.Visibility = Visibility.Visible;

               if (rdoDeposit.IsChecked == true)
               {
                    if (ut.Deposit())
                    {
                         lblUpdateValidation.Content = "Deposit Successful";
                         lblUpdateValidation.Foreground = Brushes.Green;
                    }
                    else
                    {
                         lblUpdateValidation.Content = "Invalid Deposit Amount";
                         lblUpdateValidation.Foreground = Brushes.Red;
                    }
               }
               else
               {
                    if (ut.Withdraw())
                    {
                         lblUpdateValidation.Content = "Withdrawal Successful";
                         lblUpdateValidation.Foreground = Brushes.Green;
                    }
                    else
                    {
                         lblUpdateValidation.Content = "Insufficient Funds";
                         lblUpdateValidation.Foreground = Brushes.Red;
                    }
               }

               PopulateDetails();

               txtAmount.Clear();

               //Refresh the DataGrid in MainWindow
               var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
               mainWindow?.RefreshDataGrid();
          }

          public void PopulateDetails()
          {
               int accountNum = (int)cboAccountNumber.SelectedValue;
               dt = ad.PopulateAccountDetails(accountNum);
               txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
               txtSurname.Text = dt.Rows[0]["Surname"].ToString();
               txtCurrentBalance.Text = dt.Rows[0]["Balance"].ToString();
               balance = decimal.Parse(dt.Rows[0]["Balance"].ToString());
               overdraftLimit = decimal.Parse(dt.Rows[0]["OverdraftLimit"].ToString());
          }
     }
}
