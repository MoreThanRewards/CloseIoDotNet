namespace CloseIoDotNet.Rest.Entities.Requests
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using RequestFactories;
    using RestSharp;

    public interface IQueryRequest<T> where T : IEntityQueryable, new()
    {
        IEnumerable<IEntityField> Fields { get; set; }
        string Id { get; set; }
        IRestRequest CreateRestRequest(IRestRequestFactory restRequestFactory);
    }
}