namespace CloseIoDotNet.Test.Rest.RequestFactories
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CloseIoDotNet.Rest.RequestFactories;
    using CloseIoDotNet.Rest.Serialization;
    using RestSharp;

    [TestClass]
    public class RestRequestFactoryTest
    {
        [TestMethod]
        public void TestCreateWithUri()
        {
            var unit = new RestRequestFactory();
            var result = unit.Create(new Uri("/resource/", UriKind.Relative), Method.GET);
            Assert.IsNotNull(result);
            Assert.AreEqual(DataFormat.Json, result.RequestFormat);
            Assert.IsInstanceOfType(result.JsonSerializer, typeof(NewtonsoftSerializer));
        }

        [TestMethod]
        public void TestCreateWithString()
        {
            var unit = new RestRequestFactory();
            var result = unit.Create("/resource/", Method.GET);
            Assert.IsNotNull(result);
            Assert.AreEqual(DataFormat.Json, result.RequestFormat);
            Assert.IsInstanceOfType(result.JsonSerializer, typeof(NewtonsoftSerializer));
        }

        [TestMethod]
        public void TestCreateWithUriThrowsArgumentNullExceptionWhenUriNull()
        {
            var unit = new RestRequestFactory();
            try
            {
                Uri uri = null;
                var result = unit.Create(uri, Method.GET);
                Assert.Fail("Expected ArgumentNullException not thrown.");
            }
            catch (ArgumentNullException)
            {
                //expected
            }
        }

        [TestMethod]
        public void TestCreateWithStringThrowsArgumentExceptionWhenResourceNullOrEmpty()
        {
            var unit = new RestRequestFactory();

            try
            {
                string resource = null;
                var result = unit.Create(resource, Method.GET);
                Assert.Fail("Expected ArgumentException not thrown.");
            }
            catch (ArgumentException)
            {
                //expected
            }

            try
            {
                string resource = string.Empty;
                var result = unit.Create(resource, Method.GET);
                Assert.Fail("Expected ArgumentException not thrown.");
            }
            catch (ArgumentException)
            {
                //expected
            }

            var pass = unit.Create("pass", Method.GET);
        }
    }
}
