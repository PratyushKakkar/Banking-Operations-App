using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Banking_Operations_App;

namespace Testing.GUI_Tests
{
     [TestClass]
     public class TablesTests
     {
          [TestMethod]
          public void CountiesEnum_ContainsExpectedValues()
          {
               // Arrange & Act
               var counties = Enum.GetValues(typeof(Tables.Counties));

               // Assert
               Assert.AreEqual(32, counties.Length, "Should have 32 counties");
               
          }

          [TestMethod]
          public void CountiesEnum_HasCorrectFirstAndLastValues()
          {
               // Arrange & Act
               var firstCounty = Tables.Counties.Antrim;
               var lastCounty = Tables.Counties.Wicklow;

               // Assert
               Assert.AreEqual(0, (int)firstCounty, "Antrim should be first with value 0");
               Assert.AreEqual(31, (int)lastCounty, "Wicklow should be last with value 31");
          }

          [TestMethod]
          public void CountiesEnum_ContainsSpecificCounties()
          {
               // Arrange & Act & Assert
               Assert.IsTrue(Enum.IsDefined(typeof(Tables.Counties), "Cork"));
               Assert.IsTrue(Enum.IsDefined(typeof(Tables.Counties), "Galway"));
               Assert.IsTrue(Enum.IsDefined(typeof(Tables.Counties), "Mayo"));
          }

          [TestMethod]
          public void CountiesEnum_DoesNotContainInvalidValues()
          {
               // Arrange & Act & Assert
               Assert.IsFalse(Enum.IsDefined(typeof(Tables.Counties), "London"));
               Assert.IsFalse(Enum.IsDefined(typeof(Tables.Counties), "Belfast"));
               Assert.IsFalse(Enum.IsDefined(typeof(Tables.Counties), "123"));
          }
     }
}
