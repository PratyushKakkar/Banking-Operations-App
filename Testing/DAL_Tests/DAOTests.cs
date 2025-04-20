using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace UnitTests.DAL_Tests
{
          [TestClass]
          public class DAOTests
          {
               private DAO _dao;

               [TestInitialize]
               public void Setup()
               {
                    _dao = new DAO();
               }

               [TestMethod]
               public void OpenCon_ShouldOpenSqlConnection()
               {
                    // Act
                    var connection = _dao.OpenCon();

                    // Assert
                    Assert.IsNotNull(connection);
                    Assert.AreEqual(ConnectionState.Open, connection.State);

                    // Clean up
                    _dao.CloseCon();
               }

               [TestMethod]
               public void CloseCon_ShouldCloseSqlConnection()
               {
                    // Arrange
                    var connection = _dao.OpenCon();

                    // Act
                    _dao.CloseCon();

                    // Assert
                    Assert.AreEqual(ConnectionState.Closed, connection.State);
               }
          }
     }

