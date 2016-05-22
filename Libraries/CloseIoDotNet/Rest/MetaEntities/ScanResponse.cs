namespace CloseIoDotNet.Rest.MetaEntities
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Definitions;
    using Newtonsoft.Json;

    public class ScanResponse<T> where T : IEntity
    {
        #region Instance Variables
        private IEnumerable<T> _data;
        #endregion

        #region Properties
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