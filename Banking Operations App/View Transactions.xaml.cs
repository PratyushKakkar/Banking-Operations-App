using BIZ;
using DAL;
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
using System.Xml.Linq;

namespace Banking_Operations_App
{
     /// <summary>
     /// Interaction logic for View_Transactions.xaml
     /// </summary>
     public partial class View_Transactions : Window
     {
          public View_Transactions()
          {
               InitializeComponent();
          }

          DataTable dt;
          AccountData ad = new AccountData();
          TransactionData td = new TransactionData();

          private void Window_Loaded(object sender, RoutedEventArgs e)
          {
               dt = ad.PopulateAccNums();
               cboAccountNumber.ItemsSource = dt.DefaultView;
               cboAccountNumber.DisplayMemberPath = "AccountNumber";
               cboAccountNumber.SelectedValuePath = "AccountNumber";

               dt = td.GetTransactionHistory();
               dgvTransactionHistory.ItemsSource = dt.DefaultView;
          }

          private void btnViewAllData_Click(object sender, RoutedEventArgs e)
          {
               dt = td.GetTransactionHistory();
               dgvTransactionHistory.ItemsSource = dt.DefaultView;

               //Refresh the DataGrid in MainWindow
               var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
               mainWindow?.RefreshDataGrid();
          }

          private void btnViewUser_Click(object sender, RoutedEventArgs e)
          {
               int accountNum = int.Parse(cboAccountNumber.SelectedValue.ToString());
               dt = td.GetUserHistory(accountNum);
               dgvTransactionHistory.ItemsSource = dt.DefaultView;

               //Refresh the DataGrid in MainWindow
               var mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
               mainWindow?.RefreshDataGrid();
          }

          private void cboAccountNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
          {
              btnViewUser.IsEnabled = true;
               btnDisplayXML.IsEnabled = true;
               lblDisplayXML.Visibility = Visibility.Visible;
          }

          private void btnDisplayXML_Click(object sender, RoutedEventArgs e)
          {
               int accountNum = int.Parse(cboAccountNumber.SelectedValue.ToString());

               ExportXML ex = new ExportXML();
               XDocument xmlDoc = ex.GetUserDataAsXDocument(accountNum);

               ViewXML v = new ViewXML();
               v.Show();
               v.DisplayHighlightedXml(xmlDoc);
          }
     }
}
