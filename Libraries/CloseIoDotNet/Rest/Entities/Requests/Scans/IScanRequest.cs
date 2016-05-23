namespace CloseIoDotNet.Rest.Entities.Requests.Scans
{
    using System;
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Entities.Fields;
    using CloseIoDotNet.Rest.Entities.Responses;
    using RestSharp;

    public interface IScanRequest<T> : IRequest where T : IEntity, IEntityScannable, new()
    {
        #region Properties
        IEnumerable<IEntityField> Fields { get; set; }
        string SearchQuery { get; set; }
        #endregion

        #region Methods
        IRestRequest CreateBaseRestRequest(int skip, int limit);
        IScanResponse<T> ExecuteScanRestRequest(IRestRequest request);
        #endregion
    }
}