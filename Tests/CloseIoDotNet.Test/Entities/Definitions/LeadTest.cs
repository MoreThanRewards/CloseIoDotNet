namespace CloseIoDotNet.Test.Entities.Definitions
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void TestScannableFields()
        {
            var unit = new Lead();
            var result = unit.ScannableFields;
            Assert.IsNotNull(result);
        }
    }
}
