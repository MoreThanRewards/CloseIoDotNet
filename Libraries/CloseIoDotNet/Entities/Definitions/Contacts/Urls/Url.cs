namespace CloseIoDotNet.Entities.Definitions.Contacts.Urls
{
    using Fields;
    using Newtonsoft.Json;

    public class Url : AEntity<Url>
    {
        #region Properties
        [EntityField(belongsTo: typeof(Url), name: "Address", serializedName: "url", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Address { get; set; }

        [EntityField(belongsTo: typeof(Url), name: "Type", serializedName: "type", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        #endregion
    }
}