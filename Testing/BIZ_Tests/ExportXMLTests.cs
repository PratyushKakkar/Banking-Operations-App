using BIZ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Testing.BIZ_Tests
{
     [TestClass]
     public class ExportXMLTests
     {
          private ExportXML exporter;

          [TestInitialize]
          public void Setup()
          {
               string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Anku\Desktop\Class Notes\Year 2\OOP\Banking-Operations-App\Banking Operations App\DB.mdf;Integrated Security=True";
               exporter = new ExportXML(con);
          }

          [TestMethod]
          public void GetUserDataAsXDocument_ShouldReturnValidXml()
          {
               // Arrange
               int testAccountNumber = 10000000; 

               // Act
               XDocument result = exporter.GetUserDataAsXDocument(testAccountNumber);

               // Assert
               Assert.IsNotNull(result);
               Assert.IsTrue(result.Root.Name == "UserData");

          }
     }
}
