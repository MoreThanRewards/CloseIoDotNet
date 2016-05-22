namespace CloseIoDotNet.Rest.Entities.Requests
{
    using System;
    using ClientFactories;
    using CloseIoDotNet.Entities.Definitions;
    using RequestFactories;
    using RestSharp;

    public class QueryRequest<T> : IQueryRequest<T> where T : IEntityQueryable, new()
    {
        #region Properties - Interface
        public string Id { get; set; }
        #endregion

        #region Methods - Interface
        public IRestRequest CreateRestRequest(IRestRequestFactory restRequestFactory)
        {
            if (restRequestFactory == null)
            {
                throw new ArgumentNullException(nameof(restRequestFactory));
            }

            var result = CreateRestRequest(restRequestFactory, Id);

            return result;
        }
        #endregion

        #region Methods
        private IRestRequest CreateRestRequest(IRestRequestFactory restRequestFactory, string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id is required and cannot be null or empty.");
            }

            var result = restRequestFactory.Create((new T()).GenerateQueryResource(id), Method.GET);

            return result;
        }
        #endregion
    }
}