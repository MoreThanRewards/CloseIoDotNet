using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloseIoDotNet.Test.Rest.ClientFactories
{
    using CloseIoDotNet.Rest.ClientFactories;
    using RestSharp.Authenticators;

    [TestClass]
    public class RestClientFactoryTest
    {
        [TestMethod]
        public void TestCreate()
        {
            var unit = new RestClientFactory();
            var result = unit.Create("unit test");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Authenticator, typeof(HttpBasicAuthenticator));
            Assert.IsNotNull(result.BaseUrl);
        }

        [TestMethod]
        public void TestArgumentExceptionOnNullOrEmptyApiKey()
        {
            var unit = new RestClientFactory();

            try
            {
                unit.Create(null);
                Assert.Fail("Expected ArgumentException not thrown.");
            }
            catch (ArgumentException)
            {
                //expected
            }

            try
            {
                unit.Create(string.Empty);
                Assert.Fail("Expected ArgumentException not thrown.");
            }
            catch (ArgumentException)
            {
                //expected
            }

            unit.Create("not empty");
            //passes without exception
        }
    }
}
