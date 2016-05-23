namespace CloseIoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using CloseIoDotNet.Rest.Utilities;
    using Entities.Definitions;
    using Entities.Fields;
    using Ioc;
    using Rest.ClientFactories;
    using Rest.Entities.Requests;
    using Rest.Entities.ResponseEnumerables;
    using Rest.RequestFactories;
    using RestSharp;

    public class CloseIoDotNetContext : ICloseIoDotNetContext
    {
        #region Instance Variables
        private IRestClient _restClient;
        private IRestRequestFactory _restRequestFactory;
        #endregion

        #region Properties
        private IRestClient RestClient
        {
            get
            {
                if (_restClient == null)
                {
                    throw new InvalidOperationException("IRestClient not initialized.");
                }
                return _restClient;
            }
            set { _restClient = value; }
        }
        private IRestRequestFactory RestRequestFactory
        {
            get
            {
                return _restRequestFactory ??
                       (_restRequestFactory = Factory.Create<IRestRequestFactory, RestRequestFactory>());
            }
            set { _restRequestFactory = value; }
        }
        private static IRestResponseValidator RestResponseValidator
            => Factory.Create<IRestResponseValidator, RestResponseValidator>();
        #endregion

        #region Constructors
        public CloseIoDotNetContext(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("apiKey is required and cannot be null or empty.", nameof(apiKey));
            }

            RestClient = CreateIRestClient(apiKey);
        }
        #endregion

        #region Methods - Interface
        public void Dispose()
        {
            _restRequestFactory = null;
            _restClient = null;
        }


        public T Query<T>(string id) where T : IEntityQueryable, new()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is required and cannot be null or empty.");
            }

            var request = Factory.Create<IQueryRequest<T>, QueryRequest<T>>();
            request.Id = id;
            var result = Query<T>(request);

            return result;
        }

        public T Query<T>(string id,IEnumerable<IEntityField> fields) where T : IEntityQueryable, new()
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is required and cannot be null or empty.");
            }

            if (fields.Any() == false)
            {
                throw new ArgumentException("fields must contain at least one field to retrieve", nameof(fields));
            }

            if (fields.Any(entry => entry.BelongsTo != typeof (T)))
            {
                throw new ArgumentException("All fields must be a member of the entity being scanned.", nameof(fields));
            }

            var request = Factory.Create<IQueryRequest<T>, QueryRequest<T>>();
            request.Id = id;
            request.Fields = fields;
            var result = Query<T>(request);
            return result;

        }

        public IEnumerable<T> Scan<T>() where T : IEntityScannable, new()
        {
            var scanRequest = new ScanRequest<T>()
            {
                RestClient = RestClient,
                RestRequestFactory = RestRequestFactory
            };

            var result = new ScanEnumerable<T>(scanRequest);
            return result;
        }

        public IEnumerable<T> Scan<T>(IEnumerable<IEntityField> fields) where T : IEntityScannable, new()
        {
            if (fields == null)
            {
                throw new ArgumentNullException(nameof(fields));
            }

            if (fields.Any() == false)
            {
                throw new ArgumentException("fields must contain at least one field to retrieve", nameof(fields));
            }

            if (fields.Any(entry => entry.BelongsTo != typeof (T)))
            {
                throw new ArgumentException("All fields must be a member of the entity being scanned.", nameof(fields));
            }

            var scanRequest = new ScanRequest<T>()
            {
                RestClient = RestClient,
                RestRequestFactory = RestRequestFactory
            };

            var result = new ScanEnumerable<T>(scanRequest);
            return result;
        }
        #endregion

        #region Methods
        private static IRestClient CreateIRestClient(string apiKey)
        {
            var restClientFactory = Factory.Create<IRestClientFactory, RestClientFactory>();
            var result = restClientFactory.Create(apiKey);
            return result;
        }

        private T Query<T>(IQueryRequest<T> request) where T : IEntityQueryable, new()
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var restRequest = request.CreateRestRequest(RestRequestFactory);
            var restResponse = RestClient.Execute<T>(restRequest);
            RestResponseValidator.Validate(restRequest, restResponse);
            var result = restResponse.Data;
            return result;
        }
        #endregion
    }
}