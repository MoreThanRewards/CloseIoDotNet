namespace CloseIoDotNet.Entities.Definitions.Contacts.Phones
{
    using Fields.Contacts.Phones;
    using Newtonsoft.Json;

    public class Phone : AEntity<Phone>
    {
        #region Properties
        [PhoneEntityField(name: "PhoneNumber", serializedName: "phone", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [PhoneEntityField(name: "PhoneNumberFormatted", serializedName: "phone_formatted", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "phone_formatted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumberFormatted { get; set; }

        [PhoneEntityField(name: "Type", serializedName: "type", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}