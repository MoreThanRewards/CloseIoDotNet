namespace CloseIoDotNet.Rest.Entities.Requests
{
    using System;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Ioc;
    using CloseIoDotNet.Rest.ClientFactories;
    using CloseIoDotNet.Rest.Utilities;
    using RequestFactories;
    using RestSharp;

    public abstract class ARequest<T> : IRequest where T : IEntity
    {
        #region Constants
        protected const string QueryKeySkip = "_skip";
        protected const string QueryKeyLimit = "_limit";
        protected const string QueryKeyFields = "_fields";
        protected const string QueryKeyQuery = "_query";
        #endregion

        #region Instance Variables
        private string _apiKey;
        private IRestClient _restClient;
        private IRestRequestFactory _restRequestFactory;
        #endregion

        #region Properties - Interface
        public string ApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(_apiKey))
                {
                    throw new InvalidOperationException("ApiKey not initialized.");
                }
                return _apiKey;
            }
            set { _apiKey = value; }
        }
        public IRestClient RestClient
        {
            get { return _restClient ?? (_restClient = Factory.Create<IRestClientFactory, RestClientFactory>().Create(ApiKey)); }
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
        #endregion
        #region Properties
        protected static IRestResponseValidator RestResponseValidator
            => Factory.Create<IRestResponseValidator, RestResponseValidator>();
        protected static IFieldsParameterValueFactory FieldParameterValueFactory
            => Factory.Create<IFieldsParameterValueFactory, FieldsParameterValueFactory>();
        #endregion

        #region Constructors
        protected ARequest() { }
        protected ARequest(string apiKey)
        {
            ApiKey = apiKey;
        }
        protected ARequest(string apiKey, IRestClient restClient)
        {
            ApiKey = apiKey;
            RestClient = restClient;
        }

        protected ARequest(string apiKey, IRestClient restClient, IRestRequestFactory restRequestFactory)
        {
            ApiKey = apiKey;
            RestClient = restClient;
            RestRequestFactory = restRequestFactory;
        }
        #endregion

        #region Methods - Interface
        public void Dispose()
        {
            _apiKey = null;
            _restClient = null;
            _restRequestFactory = null;
        }
        #endregion

        #region Methods
        protected IRestRequest CreateRestRequest(string resource, Method method)
        {
            var result = RestRequestFactory.Create(resource, method);
            return result;
        }
        #endregion
    }
}