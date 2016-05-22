using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloseIoDotNet.Test.Entities.Definitions
{
    using System.Linq;
    using CloseIoDotNet.Entities.Definitions;

    [TestClass]
    public class LeadTest
    {
        [TestMethod]
        public void TestFieldAttributeEnum()
        {
            var unit = new Lead();
            var result = unit.EntityFields;
            Assert.AreEqual(1, result.Count(entry => entry.Name.Equals("Id")));
        }
    }
}
