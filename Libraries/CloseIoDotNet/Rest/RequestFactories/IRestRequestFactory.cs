namespace CloseIoDotNet.Rest.RequestFactories
{
    using System;
    using RestSharp;

    public interface IRestRequestFactory
    {
        IRestRequest Create(Uri resourceUri, Method method);
        IRestRequest Create(string resource, Method method);
    }
}