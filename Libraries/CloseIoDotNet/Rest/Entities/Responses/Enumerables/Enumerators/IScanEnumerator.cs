namespace CloseIoDotNet.Rest.Entities.Responses.Enumerables.Enumerators
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using CloseIoDotNet.Rest.Entities.Requests.Scans;

    public interface IScanEnumerator<T> : IEnumerator<T> where T : IEntityScannable, new()
    {
         IScanRequest<T> ScanRequest { get; set; } 
    }
}