using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DAL;

namespace BIZ
{
     public class ExportXML
     {
          TransactionData td;
          AccountData ad;

          public ExportXML()
          {
               td = new TransactionData();
               ad = new AccountData();
          }

          public XDocument GetUserDataAsXDocument(int accountNumber)
          {
               DataTable userDetails, userTransactions;

               //Populate User Details from User table
               userDetails = ad.PopulateAccountDetails(accountNumber);
               //Populate User Transactions from Transaction table
               userTransactions = td.GetUserHistory(accountNumber);

               //Create Serialised XML structure
               return new XDocument(
                   new XElement("UserData",
                       // User details section
                       CreateXmlSection("UserDetails", "User", userDetails),

                       // Transaction history section with iteration
                       CreateXmlSection("TransactionHistory", "Transaction", userTransactions)
                   )
               );
          }

          // Helper method to create XML sections from a DataTable
          private XElement CreateXmlSection(string sectionName, string rowElementName, DataTable table)
          {
               // Iterate through each row of the DataTable and create XML for each row
               return new XElement(sectionName,
                   table.AsEnumerable().Select(row =>
                       new XElement(rowElementName,
                           table.Columns.Cast<DataColumn>().Select(col =>
                               new XElement(col.ColumnName, row[col]) // Create an XML element for each column
                           )
                       )
                   )
               );
          }

          //To Run Tests ONLY
          public ExportXML(string connectionString)
          {
               td = new TransactionData(connectionString);
               ad = new AccountData(connectionString);
          }
     }

}
