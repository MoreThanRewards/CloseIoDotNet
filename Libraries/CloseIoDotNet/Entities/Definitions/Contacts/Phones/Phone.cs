namespace CloseIoDotNet.Entities.Definitions.Contacts.Phones
{
    using Newtonsoft.Json;

    public class Phone : IEntity
    {
        #region Properties
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "phone_formatted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumberFormatted { get; set; }

        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}