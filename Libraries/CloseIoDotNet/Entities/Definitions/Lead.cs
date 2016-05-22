namespace CloseIoDotNet.Entities.Definitions
{
    using System;
    using System.Collections.Generic;
    using Addresses;
    using Contacts;
    using Fields;
    using Newtonsoft.Json;
    using Opportunities;
    using Tasks;

    public class Lead : AEntity<Lead>, IEntityQueryable
    {
        #region Instance Variables
        private IEnumerable<Address> _addresses;
        private IEnumerable<Contact> _contacts;
        private IDictionary<string, dynamic> _custom;
        private IEnumerable<dynamic> _integrationLinks;
        private IEnumerable<Opportunity> _opportunities;
        private IEnumerable<Task> _tasks;
        private BaseEntityQueryable _baseEntityQueryable;
        #endregion

        #region Properties
        [LeadEntityField(name: "Id", serializedName: "id", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: true)]
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }

        [LeadEntityField(name: "Addresses", serializedName: "addresses", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "addresses", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            set { _addresses = value; }
        }

        [LeadEntityField(name: "Contacts", serializedName: "contacts", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "contacts", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Contact> Contacts
        {
            get { return _contacts ?? (_contacts = new List<Contact>()); }
            set { _contacts = value; }
        }

        [LeadEntityField(name: "CreatedBy", serializedName: "created_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [LeadEntityField(name: "CreatedByName", serializedName: "created_by_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedByName { get; set; }

        [LeadEntityField(name: "Custom", serializedName: "custom", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "custom", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IDictionary<string, dynamic> Custom
        {
            get { return _custom ?? (_custom = new Dictionary<string, dynamic>()); }
            set { _custom = value; }
        }

        [LeadEntityField(name: "DateCreated", serializedName: "date_created", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [LeadEntityField(name: "DateUpdated", serializedName: "date_updated", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [LeadEntityField(name: "DisplayName", serializedName: "display_name", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "display_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string DisplayName { get; set; }

        [LeadEntityField(name: "HtmlUrl", serializedName: "html_url", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "html_url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string HtmlUrl { get; set; }

        [LeadEntityField(name: "Name", serializedName: "name", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [LeadEntityField(name: "IntegrationLinks", serializedName: "integration_links", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "integration_links", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<dynamic> IntegrationLinks //TODO figure out how to tackle these, if at all.
        {
            get { return _integrationLinks ?? (_integrationLinks = new List<dynamic>()); }
            set { _integrationLinks = value; }
        }

        [LeadEntityField(name: "Opportunities", serializedName: "opportunities", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "opportunities", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Opportunity> Opportunities
        {
            get { return _opportunities ?? (_opportunities = new List<Opportunity>()); }
            set { _opportunities = value; }
        }

        [LeadEntityField(name: "OrganizationId", serializedName: "organization_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [LeadEntityField(name: "StatusId", serializedName: "status_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "status_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusId { get; set; }

        [LeadEntityField(name: "StatusLabel", serializedName: "status_label", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "status_label", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string StatusLabel { get; set; }

        [LeadEntityField(name: "Tasks", serializedName: "tasks", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "tasks", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Task> Tasks
        {
            get { return _tasks ?? (_tasks = new List<Task>()); }
            set { _tasks = value; }
        }

        [LeadEntityField(name: "Url", serializedName: "url", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "url", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Url { get; set; }

        [LeadEntityField(name: "UpdatedBy", serializedName: "updated_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [LeadEntityField(name: "UpdatedByName", serializedName: "updated_by_name", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedByName { get; set; }

        [LeadEntityField(name: "Description", serializedName: "description", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "description", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonIgnore]
        private BaseEntityQueryable BaseEntityQueryable
            => (_baseEntityQueryable ?? (_baseEntityQueryable = new BaseEntityQueryable()
            {
                QueryResourceFormat = $"/lead/{BaseEntityQueryable.QueryResourceIdKey}/"
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