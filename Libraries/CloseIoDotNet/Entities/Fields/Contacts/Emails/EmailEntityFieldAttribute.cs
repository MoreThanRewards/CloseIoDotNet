namespace CloseIoDotNet.Entities.Fields.Contacts.Emails
{
    using System;
    using Definitions.Contacts.Emails;
    using Ioc;

    public class EmailEntityFieldAttribute : Attribute, IEntityField<Email>
    {
        #region Instance Variables
        private IEntityField<Email> _entityField;
        #endregion

        #region Properties - Interface
        private IEntityField<Email> EntityField
        {
            get
            {
                if (_entityField == null)
                {
                    throw new InvalidOperationException("EntityField not initialized.");
                }
                return _entityField;
            }
            set { _entityField = value; }
        }

        public Type BelongsTo => EntityField.BelongsTo;
        public string Name => EntityField.Name;
        public string SerializedName => EntityField.SerializedName;
        public bool IsRequiredOnCreate => EntityField.IsRequiredOnCreate;
        public bool IsAllowedOnCreate => EntityField.IsAllowedOnCreate;
        public bool IsRequiredOnUpdate => EntityField.IsRequiredOnUpdate;
        public bool IsAllowedOnUpdate => EntityField.IsAllowedOnUpdate;
        public bool IsRequiredOnDelete => EntityField.IsRequiredOnDelete;
        #endregion

        #region Constructors
        public EmailEntityFieldAttribute(string name, string serializedName, bool isRequiredOnCreate, bool isAllowedOnCreate,
            bool isRequiredOnUpdate, bool isAllowedOnUpdate, bool isRequiredOnDelete)
        {
            EntityField = Factory.Create<IEntityField<Email>, BaseEntityField<Email>>
            (
                name,
                serializedName,
                isRequiredOnCreate,
                isAllowedOnCreate,
                isRequiredOnUpdate,
                isAllowedOnUpdate,
                isRequiredOnDelete
            );
        }
        #endregion
    }
}