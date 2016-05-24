namespace CloseIoDotNet.Entities.Definitions.Tasks
{
    using System;
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Enumerations;
    using Fields;
    using Newtonsoft.Json;

    public class Task : AEntity<Task>, IEntityQueryable, IEntityScannable
    {
        #region Constants
        private const string ScanResource = "task/";
        private static readonly IEnumerable<ScanType> ScanTypes = new []
        {
            ScanType.Base
        };
        #endregion

        #region Instance Variables
        private BaseEntityQueryable _baseEntityQueryable;
        #endregion

        #region Properties
        [EntityField(belongsTo: typeof(Task), name: "Id", serializedName: "id", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: true)]
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }
        

        [EntityField(belongsTo: typeof(Task), name: "AssignedTo", serializedName: "assigned_to", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "assigned_to", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AssignedTo { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "AssignedToName", serializedName: "assigned_to_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "assigned_to_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AssignedToName { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "ContactId", serializedName: "contact_id", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "contact_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactId { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "ContactName", serializedName: "contact_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "contact_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "CreatedBy", serializedName: "created_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "CreatedByName", serializedName: "created_by_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "Date", serializedName: "date", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? Date { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "DateCreated", serializedName: "date_created", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "DateUpdated", serializedName: "date_updated", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "DueDate", serializedName: "due_date", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "due_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DueDate { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "IsComplete", serializedName: "is_complete", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "is_complete", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsComplete { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "IsDateless", serializedName: "is_dateless", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "is_dateless", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsDateless { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "LeadId", serializedName: "lead_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "lead_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadId { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "LeadName", serializedName: "lead_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "lead_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadName { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "ObjectId", serializedName: "object_id", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "object_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ObjectId { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "ObjectType", serializedName: "object_type", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "object_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ObjectType { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "OrganizationId", serializedName: "organization_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "Text", serializedName: "text", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "Type", serializedName: "_type", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        
        [EntityField(belongsTo: typeof(Task), name: "UpdatedBy", serializedName: "updated_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "UpdatedByName", serializedName: "updated_by_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [EntityField(belongsTo: typeof(Task), name: "View", serializedName: "view", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "view", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string View { get; set; }

        [JsonIgnore]
        private BaseEntityQueryable BaseEntityQueryable
            => (_baseEntityQueryable ?? (_baseEntityQueryable = new BaseEntityQueryable()
            {
                QueryResourceFormat = $"/task/{BaseEntityQueryable.QueryResourceIdKey}/"
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