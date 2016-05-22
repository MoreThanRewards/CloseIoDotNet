namespace CloseIoDotNet.Rest.ClientFactories
{
    using System;
    using Ioc;
    using RestSharp;
    using RestSharp.Authenticators;
    using RestSharp.Deserializers;
    using Serialization;

    public class RestClientFactory : IRestClientFactory
    {
        #region Constants
        private const string BaseUrl = "https://app.close.io/api/v1/";
        #endregion

        #region Instance Variables
        private IDeserializer _jsonDeserializer;
        #endregion

        #region Properties
        private IDeserializer JsonDeserializer
            => _jsonDeserializer ?? (_jsonDeserializer = Factory.Create<IDeserializer, NewtonsoftDeserializer>());
        #endregion

        #region Methods - Interface
        public IRestClient Create(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("apiKey is required and cannot be null or empty.", nameof(apiKey));
            }

            var result = new RestClient(BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(apiKey, string.Empty),
            };

            result.AddHandler("application/json", JsonDeserializer);
            result.AddHandler("text/json", JsonDeserializer);
            result.AddHandler("text/x-json", JsonDeserializer);
            result.AddHandler("text/javascript", JsonDeserializer);
            result.AddHandler("*+json", JsonDeserializer);

            return result;
        }
        #endregion

    }
}