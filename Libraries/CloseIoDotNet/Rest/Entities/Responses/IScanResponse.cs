namespace CloseIoDotNet.Rest.Entities.Responses
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using Newtonsoft.Json;

    public interface IScanResponse<T> where T : IEntity, IEntityScannable, new()
    {
        #region Properties
        [JsonProperty(PropertyName = "has_more", DefaultValueHandling = DefaultValueHandling.Ignore)]
        bool HasMore { get; set; }

        [JsonProperty(PropertyName = "total_results", DefaultValueHandling = DefaultValueHandling.Ignore)]
        int TotalResults { get; set; }

        [JsonProperty(PropertyName = "data", DefaultValueHandling = DefaultValueHandling.Ignore)]
        IEnumerable<T> Data { get; set; }
        #endregion
    }
}