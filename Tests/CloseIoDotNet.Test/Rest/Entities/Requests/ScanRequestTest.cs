using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CloseIoDotNet.Test.Rest.Entities.Requests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using CloseIoDotNet.Ioc;
    using CloseIoDotNet.Rest.Entities.Requests;
    using CloseIoDotNet.Rest.Entities.Responses;
    using FakeItEasy;
    using RestSharp;

    [TestClass]
    public class ScanRequestTest
    {
        #region Test Setup/Cleanup
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

        #region Tests
        [TestMethod]
        public void TestFieldParameterGeneration()
        {
            var mockRestClient = A.Fake<IRestClient>();
            A.CallTo(mockRestClient).DoesNothing();
            A.CallTo(() => mockRestClient.Execute<ScanResponse<Lead>>(A<IRestRequest>.That.Matches(request =>
                request.Parameters.Where(param => param.Name.Equals("_fields"))
                    .Any(param => param.Value.Equals("id,name,display_name,opportunities")))))
                .Returns(new RestResponse<ScanResponse<Lead>>
                {
                    StatusCode = HttpStatusCode.OK,
                    Data = new ScanResponse<Lead>
                    {
                        HasMore = false,
                        TotalResults = 0,
                        Data = new List<Lead>()
                    }
                });
            A.CallTo(() => mockRestClient.Execute<ScanResponse<Lead>>(A<IRestRequest>.That.Not.Matches(request =>
                request.Parameters.Where(param => param.Name.Equals("_fields"))
                    .Any(param => param.Value.Equals("id,name,display_name,opportunities")))))
                    .Throws(new AssertFailedException("RestClient.Execute called with unexpected parameters"));
            Factory.DispenseForType<IRestClient, RestClient>(mockRestClient);

                
            var unit = new ScanRequest<Lead>(mockRestClient)
            {
                Fields = new List<IEntityField>()
                {
                    new EntityFieldAttribute(typeof (Lead), "Id", "id", false, false, false, false, false),
                    new EntityFieldAttribute(typeof (Lead), "Name", "name", false, false, false, false, false),
                    new EntityFieldAttribute(typeof (Lead), "DisplayName", "display_name", false, false, false, false,
                        false),
                    new EntityFieldAttribute(typeof (Lead), "Opportunities", "opportunities", false, false, false, false,
                        false),
                }
            };
            var result = unit.CreateBaseRestRequest(0, 100);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Parameters.Exists(param => param.Name.Equals("_fields")));
            var value = result.Parameters.First(entry => entry.Name.Equals("_fields")).Value;
            Assert.AreEqual("id,name,display_name,opportunities", value);
        }
        #endregion
    }
}
