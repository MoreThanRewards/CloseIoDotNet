namespace CloseIoDotNet.Entities.Fields
{
    using System;
    using Definitions;
    using Ioc;

    public class LeadEntityFieldAttribute : Attribute, IEntityField<Lead>
    {
        #region Instance Variables
        private IEntityField<Lead> _entityField;
        #endregion

        #region Properties - Interface
        private IEntityField<Lead> EntityField
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
        public LeadEntityFieldAttribute(string name, string serializedName, bool isRequiredOnCreate, bool isAllowedOnCreate,
            bool isRequiredOnUpdate, bool isAllowedOnUpdate, bool isRequiredOnDelete)
        {
            EntityField = Factory.Create<IEntityField<Lead>, BaseEntityField<Lead>>
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