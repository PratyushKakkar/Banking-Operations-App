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
using System.Security.Cryptography.X509Certificates;

namespace Banking_Operations_App
{
     /// <summary>
     /// Interaction logic for Transfer_Amount.xaml
     /// </summary>
     public partial class Transfer_Amount : Window
     {
          public Transfer_Amount()
          {
               InitializeComponent();
          }

          DataTable dt;
          AccountData ad = new AccountData();

          private void cboAccountNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
               PopSourceDetails();

               //Only Allow Internal Transfers
               if (txtAccountType.Text == "Savings")
               {
                    cboAccountNumber_Destination.Visibility = Visibility.Visible;
                    txtAccountNumber_Destination.Visibility = Visibility.Hidden;
               }
               else
               {
                    cboAccountNumber_Destination.Visibility = Visibility.Hidden;
                    txtAccountNumber_Destination.Visibility = Visibility.Visible;
               }

               //Populate Destination Account Numbers
               dt = ad.PopulateAccNums();
               cboAccountNumber_Destination.ItemsSource = dt.DefaultView;
               cboAccountNumber_Destination.DisplayMemberPath = "AccountNumber";
               cboAccountNumber_Destination.SelectedValuePath = "AccountNumber";

               //Default for Bank
               txtSortCode_Destination.Text = 101010.ToString();
          }

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {
               dt = ad.PopulateAccNums();
               cboAccountNumber.ItemsSource = dt.DefaultView;
               cboAccountNumber.DisplayMemberPath = "AccountNumber";
               cboAccountNumber.SelectedValuePath = "AccountNumber";

               txtAccountNumber_Destination.IsEnabled = true;
          }

          public void PopSourceDetails()
          {
               int accountNum = (int)cboAccountNumber.SelectedValue;
               dt = ad.PopulateAccountDetails(accountNum);
               txtFirstName.Text = dt.Rows[0]["FirstName"].ToString();
               txtSurname.Text = dt.Rows[0]["Surname"].ToString();
               txtCurrentBalance.Text = dt.Rows[0]["Balance"].ToString();
               txtAccountType.Text = dt.Rows[0]["AccountType"].ToString();
               txtSortCode.Text = dt.Rows[0]["SortCode"].ToString();
          }

          private void txtSortCode_Destination_TextChanged(object sender, TextChangedEventArgs e)
          {
               if (InputValidation.IsValidSortCode(txtSortCode_Destination.Text))
                    lblInvalidMsg_SortCode.Visibility = Visibility.Hidden;
               else
                    lblInvalidMsg_SortCode.Visibility = Visibility.Visible;

               btnTransfer.IsEnabled = (InputValidation.IsNumericOrDot(txtTransferAmount.Text)) && InputValidation.IsValidSortCode(txtSortCode_Destination.Text) ? true : false;
          }

          private void txtTrasnferAmount_TextChanged(object sender, TextChangedEventArgs e)
          {
               if(InputValidation.IsNumericOrDot(txtTransferAmount.Text))
                    lblInvalidMsg_TransferAmount.Visibility = Visibility.Hidden;
               else
                    lblInvalidMsg_TransferAmount.Visibility = Visibility.Visible;

               btnTransfer.IsEnabled = (InputValidation.IsNumericOrDot(txtTransferAmount.Text)) && InputValidation.IsValidSortCode(txtSortCode_Destination.Text)  ? true : false;
          
          }

          private void btnTransfer_Click(object sender, RoutedEventArgs e)
          {
               //Input Variables
               int destinationSortCode = int.Parse(txtSortCode_Destination.Text);
               int destinationAccountNum = (txtAccountType.Text == "Savings") ? (int)cboAccountNumber_Destination.SelectedValue : int.Parse(txtAccountNumber_Destination.Text);
               decimal transferAmount = decimal.Parse(txtTransferAmount.Text);
               string description = txtDescription.Text;
               int sourceAccountID = (int)cboAccountNumber.SelectedValue;
              
               Transfer t = new Transfer(destinationSortCode, destinationAccountNum, transferAmount, description, sourceAccountID);
               if (t.TransferFunds())
               {
                    lblMsg_Transfer.Content = "Transfer Successful!";
                    lblMsg_Transfer.Foreground = Brushes.Green;
               }
               else
               {
                    lblMsg_Transfer.Content = "Insufficient Funds!";
                    lblMsg_Transfer.Foreground = Brushes.Red;
               }

               txtTransferAmount.Text = "";
               txtDescription.Text = "";
               lblInvalidMsg_TransferAmount.Visibility = Visibility.Hidden;

               PopSourceDetails();
          }
     }
}

