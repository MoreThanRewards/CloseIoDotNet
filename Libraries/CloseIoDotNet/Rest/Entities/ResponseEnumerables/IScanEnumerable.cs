namespace CloseIoDotNet.Rest.Entities.ResponseEnumerables
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using Requests;

    public interface IScanEnumerable<T> : IEnumerable<T> where T : IEntityScannable, new()
    {
         ScanRequest<T> ScanRequest { get; set; }
    }
}