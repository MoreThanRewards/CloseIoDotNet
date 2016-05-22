
namespace CloseIoDotNet.Test.Entities.Fields
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;

    [TestClass]
    public class LeadEntityFieldAttributeTest
    {
        [TestMethod]
        public void TestConstruction()
        {
            var unit = new LeadEntityFieldAttribute("ut", "ut", true, true, true, true, true);
            Assert.AreEqual(typeof (Lead), unit.BelongsTo);
            Assert.AreEqual("ut", unit.Name);
            Assert.AreEqual("ut", unit.SerializedName);
            Assert.IsTrue(unit.IsRequiredOnCreate);
            Assert.IsTrue(unit.IsRequiredOnUpdate);
            Assert.IsTrue(unit.IsRequiredOnDelete);
            Assert.IsTrue(unit.IsAllowedOnCreate);
            Assert.IsTrue(unit.IsAllowedOnUpdate);

            var unit2 = new LeadEntityFieldAttribute("ut2", "ut2", false, false, false, false, false);
            Assert.AreEqual(typeof (Lead), unit2.BelongsTo);
            Assert.AreEqual("ut2", unit2.Name);
            Assert.AreEqual("ut2", unit2.SerializedName);
            Assert.IsFalse(unit2.IsRequiredOnCreate);
            Assert.IsFalse(unit2.IsRequiredOnUpdate);
            Assert.IsFalse(unit2.IsRequiredOnDelete);
            Assert.IsFalse(unit2.IsAllowedOnCreate);
            Assert.IsFalse(unit2.IsAllowedOnUpdate);
        }
    }
}
