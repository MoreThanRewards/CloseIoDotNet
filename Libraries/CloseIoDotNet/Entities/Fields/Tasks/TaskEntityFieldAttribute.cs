namespace CloseIoDotNet.Entities.Fields.Tasks
{
    using System;
    using Definitions.Tasks;
    using Ioc;

    public class TaskEntityFieldAttribute : Attribute, IEntityField<Task>
    {
        #region Instance Variables
        private IEntityField<Task> _entityField;
        #endregion

        #region Properties - Interface
        private IEntityField<Task> EntityField
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
        public TaskEntityFieldAttribute(string name, string serializedName, bool isRequiredOnCreate, bool isAllowedOnCreate,
            bool isRequiredOnUpdate, bool isAllowedOnUpdate, bool isRequiredOnDelete)
        {
            EntityField = Factory.Create<IEntityField<Task>, BaseEntityField<Task>>
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