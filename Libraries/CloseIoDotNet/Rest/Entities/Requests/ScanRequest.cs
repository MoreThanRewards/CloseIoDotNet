namespace CloseIoDotNet.Rest.Entities.Requests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using CloseIoDotNet.Rest.Utilities;
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
        private static IFieldsParameterValueFactory FieldParameterValueFactory
            => Factory.Create<IFieldsParameterValueFactory, FieldsParameterValueFactory>();
        private static IRestResponseValidator RestResponseValidator
            => Factory.Create<IRestResponseValidator, RestResponseValidator>();
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
            RestResponseValidator.Validate(request, response);
            return response.Data;
        }

        private static string GenerateFieldsValue(IEnumerable<IEntityField> fields)
        {
            return FieldParameterValueFactory.Create(fields);
        }
        #endregion
    }
}