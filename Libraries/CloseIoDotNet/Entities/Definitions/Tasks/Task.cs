namespace CloseIoDotNet.Entities.Definitions.Tasks
{
    using System;
    using Newtonsoft.Json;

    public class Task : IEntity
    {
        #region Properties
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }
        

        [JsonProperty(PropertyName = "assigned_to", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AssignedTo { get; set; }

        [JsonProperty(PropertyName = "assigned_to_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string AssignedToName { get; set; }

        [JsonProperty(PropertyName = "contact_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactId { get; set; }

        [JsonProperty(PropertyName = "contact_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ContactName { get; set; }

        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [JsonProperty(PropertyName = "date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? Date { get; set; }

        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [JsonProperty(PropertyName = "due_date", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DueDate { get; set; }

        [JsonProperty(PropertyName = "is_complete", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsComplete { get; set; }

        [JsonProperty(PropertyName = "is_dateless", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool? IsDateless { get; set; }

        [JsonProperty(PropertyName = "lead_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadId { get; set; }

        [JsonProperty(PropertyName = "lead_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string LeadName { get; set; }

        [JsonProperty(PropertyName = "object_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ObjectId { get; set; }

        [JsonProperty(PropertyName = "object_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string ObjectType { get; set; }

        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [JsonProperty(PropertyName = "text", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "_type", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        
        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [JsonProperty(PropertyName = "updated_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [JsonProperty(PropertyName = "view", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string View { get; set; }
        #endregion
    }
}