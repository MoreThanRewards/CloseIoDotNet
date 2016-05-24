namespace CloseIoDotNet.Entities.Definitions.Addresses
{
    using Fields;
    using Newtonsoft.Json;

    public class Address : AEntity<Address>
    {
        #region Properties
        [EntityField(belongsTo: typeof(Address), name:"AddressLine1", serializedName:"address_1", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "address_1", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AddressLine1 { get; set; }

        [EntityField(belongsTo: typeof(Address), name:"AddressLine2", serializedName:"address_2", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "address_2", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AddressLine2 { get; set; }

        [EntityField(belongsTo: typeof(Address), name:"City", serializedName:"city", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "city", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string City { get; set; }

        [EntityField(belongsTo: typeof(Address), name:"Country", serializedName:"country", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "country", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Country { get; set; }

        [EntityField(belongsTo: typeof(Address), name:"Label", serializedName:"label", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "label", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Label { get; set; }

        [EntityField(belongsTo: typeof(Address), name:"PostalZip", serializedName:"zipcode", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "zipcode", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string PostalZip { get; set; }

        [EntityField(belongsTo: typeof(Address), name:"State", serializedName:"state", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "state", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string State { get; set; }
        #endregion
    }
}