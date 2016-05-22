namespace CloseIoDotNet.Entities.Definitions.Contacts.Urls
{
    using Fields.Contacts.Urls;
    using Newtonsoft.Json;

    public class Url : AEntity<Url>
    {
        #region Properties
        [UrlEntityField(name: "Address", serializedName: "url", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        [UrlEntityField(name: "Type", serializedName: "type", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}