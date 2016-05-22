namespace CloseIoDotNet.Test.Ioc
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using CloseIoDotNet.Ioc;

    [TestClass]
    public class FactoryTest
    {
        #region Setup/Teardown
        [TestInitialize]
        public void TestSetup()
        {
            Factory.ClearDispenser();
        }
        #endregion

        #region Tests
        [TestMethod]
        public void TestDispenser()
        {
            //when type is not present in the dictionary, create the type specified in the call.
            var unit = Factory.Create<IMock, MockOne>();
            Assert.AreEqual("One", unit.Field);

            //when type is present in the dictionary, always create instance of the specified type
            Factory.DispenseForType<IMock, MockOne>(new MockTwo());
            unit = Factory.Create<IMock, MockOne>();
            Assert.AreEqual("Two", unit.Field);

            //cleardispenser should clear the dictionary
            Factory.ClearDispenser();
            unit = Factory.Create<IMock, MockOne>();
            Assert.AreEqual("One", unit.Field);
        }
        #endregion
    }

    #region Mocks
    interface IMock
    {
        string Field { get; }
    }

    class MockOne : IMock
    {
        public string Field => "One";
    }

    class MockTwo : IMock
    {
        public string Field => "Two";
    }
    #endregion
}
