namespace CloseIoDotNet.Rest.Entities.Responses.Enumerables
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Rest.Entities.Requests.Scans;

    public interface IScanEnumerable<T> : IEnumerable<T> where T : IEntityScannable, new()
    {
         IScanRequest<T> ScanRequest { get; set; }
    }
}