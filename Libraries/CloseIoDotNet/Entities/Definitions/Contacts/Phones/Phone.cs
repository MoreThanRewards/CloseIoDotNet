namespace CloseIoDotNet.Entities.Definitions.Contacts.Phones
{
    using Newtonsoft.Json;

    public class Phone : IEntity
    {
        #region Properties
        [PhoneFieldProperty(PhoneField.PhoneNumber, "phone", true, true)]
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [PhoneFieldProperty(PhoneField.PhoneNumberFormatted, "phone_formatted", false, false)]
        [JsonProperty(PropertyName = "phone_formatted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumberFormatted { get; set; }

        [PhoneFieldProperty(PhoneField.Type, "type", false, true)]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}