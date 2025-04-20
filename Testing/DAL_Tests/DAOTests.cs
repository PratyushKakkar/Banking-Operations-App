using DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Unit_Testing.DAO_Tests 
{
     [TestClass]
     public class DAOTests
     {
          private DAO _dao;

          [TestInitialize]
          public void Setup()
          {

               string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anku\Desktop\Class Notes\Year 2\OOP\Banking-Operations-App\Banking Operations App\DB.mdf;Integrated Security=True";
               _dao = new DAO(con);
          }
          
         

          [TestMethod]
          public void OpenCon_ShouldOpenConnection_WhenClosed()
          {
               var connection = _dao.OpenCon();
               Assert.AreEqual(ConnectionState.Open, connection.State);
          }

          [TestMethod]
          public void CloseCon_ShouldCloseConnection_WhenOpen()
          {
               var connection = _dao.OpenCon(); // Ensure connection is open
               _dao.CloseCon();
               Assert.AreEqual(ConnectionState.Closed, connection.State);
          }

     }
}