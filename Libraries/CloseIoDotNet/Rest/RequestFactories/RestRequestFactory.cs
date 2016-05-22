namespace CloseIoDotNet.Rest.RequestFactories
{
    using System;
    using Ioc;
    using RestSharp;
    using RestSharp.Serializers;
    using Serialization;

    public class RestRequestFactory : IRestRequestFactory
    {
        #region Instance Variables
        private ISerializer _jsonSerializer;
        #endregion

        #region Properties
        private ISerializer JsonSerializer
            => _jsonSerializer ?? (_jsonSerializer = Factory.Create<ISerializer, NewtonsoftSerializer>());
        #endregion

        #region Methods - Interface
        public IRestRequest Create(Uri resourceUri, Method method)
        {
            if (resourceUri == null)
            {
                throw new ArgumentNullException(nameof(resourceUri));
            }

            var result = new RestRequest(resourceUri, method)
            {
                JsonSerializer = JsonSerializer,
                RequestFormat = DataFormat.Json
            };

            return result;
        }

        public IRestRequest Create(string resource, Method method)
        {
            if (string.IsNullOrEmpty(resource))
            {
                throw new ArgumentException("resource is required and cannot be null or empty.", nameof(resource));
            }

            return Create(new Uri(resource, UriKind.Relative), method);
        }
        #endregion
    }
}