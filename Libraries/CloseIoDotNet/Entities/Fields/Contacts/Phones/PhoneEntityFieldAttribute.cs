namespace CloseIoDotNet.Entities.Fields.Contacts.Phones
{
    using System;
    using Definitions.Contacts.Phones;
    using Ioc;

    public class PhoneEntityFieldAttribute : Attribute, IEntityField<Phone>
    {
        #region Instance Variables
        private IEntityField<Phone> _entityField;
        #endregion

        #region Properties - Interface
        private IEntityField<Phone> EntityField
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
        public PhoneEntityFieldAttribute(string name, string serializedName, bool isRequiredOnCreate, bool isAllowedOnCreate,
            bool isRequiredOnUpdate, bool isAllowedOnUpdate, bool isRequiredOnDelete)
        {
            EntityField = Factory.Create<IEntityField<Phone>, BaseEntityField<Phone>>
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