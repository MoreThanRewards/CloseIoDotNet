namespace CloseIoDotNet.Entities.Definitions.Contacts.Emails
{
    using Fields.Contacts.Emails;
    using Newtonsoft.Json;

    public class Email : AEntity<Email>
    {
        #region Properties
        [EmailEntityField(name: "Address", serializedName: "email", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "email", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        [EmailEntityField(name: "Type", serializedName: "type", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}