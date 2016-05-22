namespace CloseIoDotNet.Test.Rest.ResponseEnumerables
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Ioc;
    using CloseIoDotNet.Rest.Entities.Requests;
    using CloseIoDotNet.Rest.Entities.ResponseEnumerables;
    using CloseIoDotNet.Rest.Entities.Responses;
    using FakeItEasy;
    using RestSharp;

    [TestClass]
    public class ScanEnumeratorTest
    {
        #region Setup/Teardown
        [TestInitialize]
        public void TestSetup()
        {
            var mockRestClient = A.Fake<IRestClient>();
            A.CallTo(mockRestClient).DoesNothing();
            Factory.DispenseForType<IRestClient, RestClient>(mockRestClient);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Factory.ClearDispenser();
        }
        #endregion

        [TestMethod]
        public void TestEnumerationWhenNoResults()
        {
            var mockRestClient = A.Fake<IRestClient>();
            A.CallTo(() => mockRestClient.Execute<ScanResponse<Lead>>(A<IRestRequest>.That.Matches(entry =>
                entry.Parameters.Any(param => param.Name == "_skip" && Equals(param.Value, "0")))))
                .Returns(new RestResponse<ScanResponse<Lead>>()
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = new ScanResponse<Lead>()
                    {
                        Data = new List<Lead>(),
                        HasMore = false,
                        TotalResults = 0
                    }
                });
            Factory.DispenseForType<IRestClient, RestClient>(mockRestClient);

            var unit = new ScanEnumerable<Lead>(new ScanRequest<Lead>(
                restClient: Factory.Create<IRestClient, RestClient>("mock API key")
                ));
            var results = unit.ToList();
            Assert.IsNotNull(results);
            Assert.AreEqual(0, results.Count);
        }

        [TestMethod]
        public void TestEnumerationWhenNoPagination()
        {
            var mockRestClient = A.Fake<IRestClient>();
            IRestResponse<ScanResponse<Lead>>[] mockRestClientResults = {
                new RestResponse<ScanResponse<Lead>>
                {
                    Data = new ScanResponse<Lead>()
                    {
                        HasMore = false,
                        TotalResults = 1,
                        Data = new[]
                        {
                            new Lead() {Id = "1"}
                        }
                    },
                    StatusCode = HttpStatusCode.OK
                }
            };
            A.CallTo(() => mockRestClient.Execute<ScanResponse<Lead>>(A<IRestRequest>.That.Matches(entry => 
                entry.Parameters.Any(param => param.Name == "_skip" && string.Equals(param.Value,"0")))))
                .ReturnsNextFromSequence(mockRestClientResults);
            A.CallTo(() => mockRestClient.Execute<ScanResponse<Lead>>(A<IRestRequest>.That.Not.Matches(entry =>
                entry.Parameters.Any(
                    param =>
                        param.Name == "_skip" && string.Equals(param.Value, "0")))))
                .Throws(new AssertFailedException("IRestClient.Execute called with unexpected value."));
            Factory.DispenseForType<IRestClient, RestClient>(mockRestClient);

            var unit = new ScanEnumerable<Lead>(new ScanRequest<Lead>(
                restClient: Factory.Create<IRestClient, RestClient>("mock API key")
                ));
            var result = unit.ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("1", result[0].Id);
        }

        [TestMethod]
        public void TestEnumerationWhenPagination()
        {
            var mockRestClient = A.Fake<IRestClient>();
            IRestResponse<ScanResponse<Lead>>[] mockRestClientResults = {
                new RestResponse<ScanResponse<Lead>>
                {
                    Data = new ScanResponse<Lead>()
                    {
                        HasMore = true,
                        TotalResults = 3,
                        Data = new[]
                        {
                            new Lead() {Id = "1"},
                            new Lead() {Id = "2"}
                        }
                    },
                    StatusCode = HttpStatusCode.OK
                },
                new RestResponse<ScanResponse<Lead>>
                {
                    Data = new ScanResponse<Lead>()
                    {
                        HasMore = false,
                        TotalResults = 3,
                        Data = new[]
                        {
                            new Lead() {Id = "3"},
                        }
                    },
                    StatusCode = HttpStatusCode.OK
                }
            };
            A.CallTo(() => mockRestClient.Execute<ScanResponse<Lead>>(A<IRestRequest>.That.Matches(entry => 
                entry.Parameters.Any(param => param.Name == "_skip" && (string.Equals(param.Value,"0") || string.Equals(param.Value,"100"))))))
                .ReturnsNextFromSequence(mockRestClientResults);
            A.CallTo(() => mockRestClient.Execute<ScanResponse<Lead>>(A<IRestRequest>.That.Not.Matches(entry =>
                entry.Parameters.Any(
                    param =>
                        param.Name == "_skip" && (string.Equals(param.Value, "0") || string.Equals(param.Value, "100"))))))
                .Throws(new AssertFailedException("IRestClient.Execute called with unexpected value."));
            Factory.DispenseForType<IRestClient, RestClient>(mockRestClient);

            var unit = new ScanEnumerable<Lead>(new ScanRequest<Lead>(
                restClient: Factory.Create<IRestClient, RestClient>("mock API key")
                ));
            var result = unit.ToList();
            Assert.AreEqual(3, result.Count);
            Assert.AreEqual("1", result[0].Id);
            Assert.AreEqual("2", result[1].Id);
            Assert.AreEqual("3", result[2].Id);
        }
    }
}
