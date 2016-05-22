namespace CloseIoDotNet.Entities.Definitions.Tasks
{
    using System;
    using Fields.Tasks;
    using Newtonsoft.Json;

    public class Task : AEntity<Task>, IEntityQueryable
    {
        #region Instance Variables
        private BaseEntityQueryable _baseEntityQueryable;
        #endregion

        #region Properties
        [TaskEntityField(name: "Id", serializedName: "id", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: true)]
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }
        

        [TaskEntityField(name: "AssignedTo", serializedName: "assigned_to", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "assigned_to", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AssignedTo { get; set; }

        [TaskEntityField(name: "AssignedToName", serializedName: "assigned_to_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "assigned_to_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AssignedToName { get; set; }

        [TaskEntityField(name: "ContactId", serializedName: "contact_id", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "contact_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactId { get; set; }

        [TaskEntityField(name: "ContactName", serializedName: "contact_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "contact_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; set; }

        [TaskEntityField(name: "CreatedBy", serializedName: "created_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [TaskEntityField(name: "CreatedByName", serializedName: "created_by_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [TaskEntityField(name: "Date", serializedName: "date", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? Date { get; set; }

        [TaskEntityField(name: "DateCreated", serializedName: "date_created", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [TaskEntityField(name: "DateUpdated", serializedName: "date_updated", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [TaskEntityField(name: "DueDate", serializedName: "due_date", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "due_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DueDate { get; set; }

        [TaskEntityField(name: "IsComplete", serializedName: "is_complete", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "is_complete", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsComplete { get; set; }

        [TaskEntityField(name: "IsDateless", serializedName: "is_dateless", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "is_dateless", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsDateless { get; set; }

        [TaskEntityField(name: "LeadId", serializedName: "lead_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "lead_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadId { get; set; }

        [TaskEntityField(name: "LeadName", serializedName: "lead_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "lead_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadName { get; set; }

        [TaskEntityField(name: "ObjectId", serializedName: "object_id", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "object_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ObjectId { get; set; }

        [TaskEntityField(name: "ObjectType", serializedName: "object_type", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "object_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ObjectType { get; set; }

        [TaskEntityField(name: "OrganizationId", serializedName: "organization_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [TaskEntityField(name: "Text", serializedName: "text", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [TaskEntityField(name: "Type", serializedName: "_type", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        
        [TaskEntityField(name: "UpdatedBy", serializedName: "updated_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [TaskEntityField(name: "UpdatedByName", serializedName: "updated_by_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [TaskEntityField(name: "View", serializedName: "view", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "view", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string View { get; set; }

        [JsonIgnore]
        private BaseEntityQueryable BaseEntityQueryable
            => (_baseEntityQueryable ?? (_baseEntityQueryable = new BaseEntityQueryable()
            {
                QueryResourceFormat = $"/task/{BaseEntityQueryable.QueryResourceIdKey}/"
            }));
        #endregion

        #region Methods - Interface
        public string GenerateQueryResource(string id)
        {
            return BaseEntityQueryable.GenerateQueryResource(id);
        }
        #endregion
    }
}