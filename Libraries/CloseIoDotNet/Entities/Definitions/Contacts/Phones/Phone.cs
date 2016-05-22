namespace CloseIoDotNet.Entities.Definitions.Contacts.Phones
{
    using Fields;
    using Newtonsoft.Json;

    public class Phone : AEntity<Phone>
    {
        #region Properties
        [EntityField(belongsTo: typeof(Phone), name: "PhoneNumber", serializedName: "phone", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "phone", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [EntityField(belongsTo: typeof(Phone), name: "PhoneNumberFormatted", serializedName: "phone_formatted", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "phone_formatted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PhoneNumberFormatted { get; set; }

        [EntityField(belongsTo: typeof(Phone), name: "Type", serializedName: "type", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}