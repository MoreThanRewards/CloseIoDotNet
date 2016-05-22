namespace CloseIoDotNet.Rest.Entities.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using Ioc;
    using RequestFactories;
    using Responses;
    using RestSharp;

    public class ScanRequest<T> where T : IEntity, IEntityScannable, new()
    {
        #region Constants
        private const string QueryKeySkip = "_skip";
        private const string QueryKeyLimit = "_limit";
        private const string QueryKeyFields = "_fields";
        #endregion

        #region Instance Variables
        private IRestClient _restClient;
        private IRestRequestFactory _restRequestFactory;
        #endregion

        #region Properties
        public IRestClient RestClient
        {
            get
            {
                if (_restClient == null)
                {
                    throw new InvalidOperationException("RestClient not initialized.");
                }
                return _restClient;
            }
            set { _restClient = value; }
        }
        public IRestRequestFactory RestRequestFactory
        {
            get
            {
                return _restRequestFactory ??
                       (_restRequestFactory = Factory.Create<IRestRequestFactory, RestRequestFactory>());
            }
            set { _restRequestFactory = value; }
        }
        public IEnumerable<IEntityField> Fields { get; set; }
        #endregion

        #region Constructors
        public ScanRequest() { }
        public ScanRequest(IRestClient restClient)
        {
            RestClient = restClient;
        }

        public ScanRequest(IRestClient restClient, IRestRequestFactory restRequestFactory)
        {
            RestClient = restClient;
            RestRequestFactory = restRequestFactory;
        }
        #endregion

        #region Methods
        public IRestRequest CreateBaseRestRequest(int skip, int limit)
        {
            if (limit <= 0)
            {
                throw new ArgumentException("Limit must be greater than 0.", nameof(limit));
            }
            var request = RestRequestFactory.Create((new T().GenerateScanResource()), Method.GET);
            request.AddQueryParameter(QueryKeySkip, skip.ToString("F0"));
            request.AddQueryParameter(QueryKeyLimit, limit.ToString("F0"));
            if (Fields != null && Fields.Any() == true)
            {
                var fieldParamValue = GenerateFieldsValue(Fields);
                request.AddQueryParameter(QueryKeyFields, fieldParamValue);
            }

            return request;
        }

        public ScanResponse<T> ExecuteScanRestRequest(IRestRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var response = RestClient.Execute<ScanResponse<T>>(request);
            ValidateResponse(request, response);
            return response.Data;
        }

        private static void ValidateResponse(IRestRequest request, IRestResponse response)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            if (
                response.StatusCode != HttpStatusCode.OK &&
                response.StatusCode != HttpStatusCode.NoContent &&
                response.StatusCode != HttpStatusCode.Created &&
                response.StatusCode != HttpStatusCode.Accepted &&
                response.StatusCode != HttpStatusCode.PartialContent
                )
            {
                //TODO inspect response type and body, issue specific exceptions
                throw new InvalidOperationException();
            }
        }

        private static string GenerateFieldsValue(IEnumerable<IEntityField> fields)
        {
            if (fields == null || fields.Any() == false)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            foreach (var field in fields)
            {
                if (stringBuilder.Length != 0)
                {
                    stringBuilder.Append(',');
                }
                stringBuilder.Append(field.SerializedName);
            }

            var result = stringBuilder.ToString();

            return result;
        }
        #endregion
    }
}