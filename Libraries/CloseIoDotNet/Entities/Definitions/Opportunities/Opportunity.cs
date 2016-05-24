namespace CloseIoDotNet.Entities.Definitions.Opportunities
{
    using System;
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Enumerations;
    using Fields;
    using Newtonsoft.Json;

    public class Opportunity : AEntity<Opportunity>, IEntityQueryable, IEntityScannable
    {
        #region Constants
        private const string ScanResource = "opportunity/";
        private static readonly IEnumerable<ScanType> ScanTypes = new []
        {
            ScanType.Base,
            ScanType.Query,
            ScanType.Fields
        };
        #endregion

        #region Instance Variables
        private IEnumerable<dynamic> _integrationLinks;
        private BaseEntityQueryable _baseEntityQueryable;
        #endregion

        #region Properties
        [EntityField(belongsTo: typeof(Opportunity), name: "Id", serializedName: "id", isRequiredOnCreate: false, isAllowedOnCreate: false,
            isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: true)]
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "Confidence", serializedName: "confidence", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: true)]
        [JsonProperty(PropertyName = "confidence", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Confidence { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "ContactId", serializedName: "contact_id", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: true)]
        [JsonProperty(PropertyName = "contact_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactId { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "ContactId", serializedName: "contact_id", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: true)]
        [JsonProperty(PropertyName = "contact_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "CreatedBy", serializedName: "created_by", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "CreatedByName", serializedName: "created_by_name", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "DateCreated", serializedName: "date_created", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "DateLost", serializedName: "date_lost", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_lost", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateLost { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "DateUpdated", serializedName: "date_updated", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "DateOn", serializedName: "date_on", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_on", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateWon { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "IntegrationLinks", serializedName: "integration_links", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "integration_links", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<dynamic> IntegrationLinks
        {
            get { return _integrationLinks ?? (_integrationLinks = new List<dynamic>()); }
            set { _integrationLinks = value; }
        }

        [EntityField(belongsTo: typeof(Opportunity), name: "LeadId", serializedName: "lead_id", isRequiredOnCreate: true,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "lead_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadId { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "LeadName", serializedName: "lead_name", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "lead_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadName { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "Note", serializedName: "note", isRequiredOnCreate: false, isAllowedOnCreate: true,
            isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "note", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Note { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "OrganizationId", serializedName: "organization_id", isRequiredOnCreate: true,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "StatusId", serializedName: "status_id", isRequiredOnCreate: true,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "status_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusId { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "StatusLabel", serializedName: "status_label", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "status_label", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusLabel { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "StatusType", serializedName: "status_type", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "status_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusType { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "UpdatedBy", serializedName: "updated_by", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "UpdatedByName", serializedName: "updated_by_name", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "UserId", serializedName: "user_id", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UserId { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "UserName", serializedName: "user_name", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "user_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UserName { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "Value", serializedName: "value", isRequiredOnCreate: true,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "value", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int? Value { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "ValueCurrency", serializedName: "value_currency", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "value_currency", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ValueCurrency { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "ValueFormatted", serializedName: "value_formatted", isRequiredOnCreate: false,
            isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "value_formatted", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ValueFormatted { get; set; }

        [EntityField(belongsTo: typeof(Opportunity), name: "ValuePeriod", serializedName: "value_period", isRequiredOnCreate: false,
            isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "value_period", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ValuePeriod { get; set; }

        [JsonIgnore]
        private BaseEntityQueryable BaseEntityQueryable
            => (_baseEntityQueryable ?? (_baseEntityQueryable = new BaseEntityQueryable()
            {
                QueryResourceFormat = $"/opportunity/{BaseEntityQueryable.QueryResourceIdKey}/"
            }));

        [JsonIgnore]
        public IEnumerable<IEntityField> ScannableFields
        {
            get
            {
                var result = new List<IEntityField>();
                result.AddRange(EntityFields);
                return result;
            }
        }

        [JsonIgnore]
        public IEnumerable<ScanType> ScanTypesSupported => ScanTypes;
        #endregion

        #region Methods - Interface
        public string GenerateQueryResource(string id)
        {
            return BaseEntityQueryable.GenerateQueryResource(id);
        }

        public string GenerateScanResource()
        {
            return ScanResource;
        }
        #endregion
    }
}