namespace CloseIoDotNet.Rest.Entities.Requests.Queries
{
    using System;
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;

    public interface IQueryRequest<T> : IRequest where T : IEntityQueryable, new()
    {
        string Id { get; set; }
        IEnumerable<IEntityField> Fields { get; set; }
        T Execute();
    }
}