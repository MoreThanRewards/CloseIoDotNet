namespace CloseIoDotNet.Rest.Entities.Responses
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using Newtonsoft.Json;

    public class ScanResponse<T> : IScanResponse<T> where T : IEntity, IEntityScannable, new()
    {
        #region Instance Variables
        private IEnumerable<T> _data;
        #endregion

        #region Properties - Interface
        [JsonProperty(PropertyName = "has_more", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool HasMore { get; set; }

        [JsonProperty(PropertyName = "total_results", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int TotalResults { get; set; }

        [JsonProperty(PropertyName = "data", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<T> Data
        {
            get { return _data ?? (_data = new List<T>()); }
            set { _data = value; }
        }
        #endregion
    }
}