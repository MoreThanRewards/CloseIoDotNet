namespace CloseIoDotNet.Rest.Entities.Requests
{
    using ClientFactories;
    using CloseIoDotNet.Entities.Definitions;
    using RequestFactories;
    using RestSharp;

    public interface IQueryRequest<T> where T : IEntityQueryable, new()
    {
        string Id { get; set; }
        IRestRequest CreateRestRequest(IRestRequestFactory restRequestFactory);
    }
}