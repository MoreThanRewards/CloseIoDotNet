namespace CloseIoDotNet.Rest.Entities.Requests
{
    using System;
    using CloseIoDotNet.Rest.RequestFactories;
    using RestSharp;

    public interface IRequest : IDisposable
    {
        #region Properties
        string ApiKey { get; set; }
        IRestClient RestClient { get; set; }
        IRestRequestFactory RestRequestFactory { get; set; }
        #endregion
    }
}