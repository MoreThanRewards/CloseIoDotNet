namespace CloseIoDotNet.Entities.Definitions.Contacts.Urls
{
    using Newtonsoft.Json;

    public class Url
    {
        #region Properties
        [JsonProperty(PropertyName = "url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}