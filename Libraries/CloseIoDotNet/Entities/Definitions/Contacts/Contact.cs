namespace CloseIoDotNet.Entities.Definitions.Contacts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Emails;
    using Fields;
    using Newtonsoft.Json;
    using Phones;
    using Urls;

    public class Contact : AEntity<Contact>, IEntityQueryable, IEntityScannable
    {
        #region Constants
        private const string ScanResource = "contact/";
        #endregion

        #region Instance Variables
        private IEnumerable<Email> _emails;
        private IEnumerable<dynamic> _integrationLinks;
        private IEnumerable<Phone> _phones;
        private IEnumerable<Url> _urls;
        private BaseEntityQueryable _baseEntityQueryable;
        #endregion

        #region Properties
        [EntityField(belongsTo: typeof(Contact), name: "Id", serializedName: "id", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: true, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Id { get; set; }


        [EntityField(belongsTo: typeof(Contact), name: "CreatedBy", serializedName: "created_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "created_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CreatedBy { get; set; }

        [EntityField(belongsTo: typeof(Contact), name: "Emails", serializedName: "emails", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "emails", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Email> Emails
        {
            get { return _emails ?? (_emails = new List<Email>()); }
            set { _emails = value; }
        } 

        [EntityField(belongsTo: typeof(Contact), name: "Name", serializedName: "name", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [EntityField(belongsTo: typeof(Contact), name: "DateCreated", serializedName: "date_created", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_created", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateCreated { get; set; }

        [EntityField(belongsTo: typeof(Contact), name: "DateUpdated", serializedName: "date_updated", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "date_updated", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime? DateUpdated { get; set; }

        [EntityField(belongsTo: typeof(Contact), name: "IntegrationLinks", serializedName: "integration_links", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "integration_links", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<dynamic> IntegrationLinks
        {
            get { return _integrationLinks ?? (_integrationLinks = new List<dynamic>()); }
            set { _integrationLinks = value; }
        }

        [EntityField(belongsTo: typeof(Contact), name: "OrganizationId", serializedName: "organization_id", isRequiredOnCreate: true, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "organization_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string OrganizationId { get; set; }

        [EntityField(belongsTo: typeof(Contact), name: "Phones", serializedName: "phones", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "phones", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Phone> Phones
        {
            get { return _phones ?? (_phones = new List<Phone>()); }
            set { _phones = value; }
        }

        [EntityField(belongsTo: typeof(Contact), name: "Title", serializedName: "title", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "title", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Title { get; set; }

        [EntityField(belongsTo: typeof(Contact), name: "UpdatedBy", serializedName: "updated_by", isRequiredOnCreate: false, isAllowedOnCreate: false, isRequiredOnUpdate: false, isAllowedOnUpdate: false, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "updated_by", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string UpdatedBy { get; set; }

        [EntityField(belongsTo: typeof(Contact), name: "Urls", serializedName: "urls", isRequiredOnCreate: false, isAllowedOnCreate: true, isRequiredOnUpdate: false, isAllowedOnUpdate: true, isRequiredOnDelete: false)]
        [JsonProperty(PropertyName = "urls", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IEnumerable<Url> Urls
        {
            get { return _urls ?? (_urls = new List<Url>()); }
            set { _urls = value; }
        }

        [JsonIgnore]
        private BaseEntityQueryable BaseEntityQueryable
            => (_baseEntityQueryable ?? (_baseEntityQueryable = new BaseEntityQueryable()
            {
                QueryResourceFormat = $"/contact/{BaseEntityQueryable.QueryResourceIdKey}/"
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