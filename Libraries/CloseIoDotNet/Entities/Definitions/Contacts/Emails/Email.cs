namespace CloseIoDotNet.Entities.Definitions.Contacts.Emails
{
    using Fields;
    using Newtonsoft.Json;

    public class Email : AEntity<Email>
    {
        #region Properties
        [EntityField(belongsTo: typeof(Email), name: "Address", serializedName: "email", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        [EntityField(belongsTo: typeof(Email), name: "Type", serializedName: "type", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}