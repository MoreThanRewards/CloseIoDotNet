namespace CloseIoDotNet.Entities.Definitions.Addresses
{
    using Newtonsoft.Json;

    public class Address
    {
        #region Properties
        [JsonProperty(PropertyName = "address_1", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AddressLine1 { get; set; }

        [JsonProperty(PropertyName = "address_2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AddressLine2 { get; set; }

        [JsonProperty(PropertyName = "city", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "country", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "label", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Label { get; set; }

        [JsonProperty(PropertyName = "zipcode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PostalZip { get; set; }

        [JsonProperty(PropertyName = "state", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string State { get; set; }
        #endregion
    }
}