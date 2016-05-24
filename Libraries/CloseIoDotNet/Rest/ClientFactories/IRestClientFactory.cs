namespace CloseIoDotNet.Rest.ClientFactories
{
    using RestSharp;

    public interface IRestClientFactory
    {
        IRestClient Create(string apiKey);
    }
}