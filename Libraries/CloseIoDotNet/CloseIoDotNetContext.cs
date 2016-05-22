namespace CloseIoDotNet
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Entities.Definitions;
    using Entities.Fields;
    using Ioc;
    using Rest.ClientFactories;
    using Rest.Entities;
    using Rest.Entities.Requests;
    using Rest.MetaEntities;
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
        #endregion

        #region Methods
        private static IRestClient CreateIRestClient(string apiKey)
        {
            var restClientFactory = Factory.Create<IRestClientFactory, RestClientFactory>();
            var result = restClientFactory.Create(apiKey);
            return result;
        }

        //TODO put response validation in its own class
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

        private T Query<T>(IQueryRequest<T> request) where T : IEntityQueryable, new()
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var restRequest = request.CreateRestRequest(RestRequestFactory);
            var restResponse = RestClient.Execute<T>(restRequest);
            ValidateResponse(restRequest, restResponse);
            var result = restResponse.Data;
            return result;
        }

        #endregion
    }
}