namespace CloseIoDotNet.Entities.Fields
{
    using System;
    using Definitions;

    public class BaseEntityField<T> : IEntityField<T> where T : IEntity
    {
        #region Constants
        private const string InvalidOperationMessageFormat = "{0} not initialized";
        #endregion

        #region Instance Variables
        private string _name;
        private string _serializedName;
        private bool? _isRequiredOnCreate;
        private bool? _isAllowedOnCreate;
        private bool? _isRequiredOnUpdate;
        private bool? _isAllowedOnUpdate;
        private bool? _isRequiredOnDelete;
        #endregion

        #region Properties - Interface
        public Type BelongsTo => typeof(T);

        public string Name
        {
            get
            {
                if (_name == null)
                {
                    throw new InvalidOperationException(GenerateInvalidOperationExceptionMessage("Name"));
                }
                return _name;
            }
            set { _name = value; }
        }

        public string SerializedName
        {
            get
            {
                if (_serializedName == null)
                {
                    throw new InvalidOperationException(GenerateInvalidOperationExceptionMessage("SerializedName"));
                }
                return _serializedName;
            }
            set { _serializedName = value; }
        }

        public bool IsRequiredOnCreate
        {
            get
            {
                if (_isRequiredOnCreate.HasValue == false)
                {
                    throw new InvalidOperationException(GenerateInvalidOperationExceptionMessage("IsRequiredOnCreate"));
                }
                return _isRequiredOnCreate.Value;
            }
            set { _isRequiredOnCreate = value; }
        }

        public bool IsAllowedOnCreate
        {
            get
            {
                if (_isAllowedOnCreate.HasValue == false)
                {
                    throw new InvalidOperationException(GenerateInvalidOperationExceptionMessage("IsAllowedOnCreate"));
                }
                return _isAllowedOnCreate.Value;
            }
            set { _isAllowedOnCreate = value; }
        }

        public bool IsRequiredOnUpdate
        {
            get
            {
                if (_isRequiredOnUpdate.HasValue == false)
                {
                    throw new InvalidOperationException(GenerateInvalidOperationExceptionMessage("IsRequiredOnUpdate"));
                }
                return _isRequiredOnUpdate.Value;
            }
            set { _isRequiredOnUpdate = value; }
        }

        public bool IsAllowedOnUpdate
        {
            get
            {
                if (_isAllowedOnUpdate.HasValue == false)
                {
                    throw new InvalidOperationException(GenerateInvalidOperationExceptionMessage("IsAllowedOnUpdate"));
                }

                return _isAllowedOnUpdate.Value;
            }
            set { _isAllowedOnUpdate = value; }
        }

        public bool IsRequiredOnDelete
        {
            get
            {
                if (_isRequiredOnDelete.HasValue == false)
                {
                    throw new InvalidOperationException(GenerateInvalidOperationExceptionMessage("IsRequiredOnDelete"));
                }
                return _isRequiredOnDelete.Value;
            }
            set { _isRequiredOnDelete = value; }
        }
        #endregion

        #region Constructors
        public BaseEntityField()
        {
            //no implementation
        } 

        public BaseEntityField (string name, string serializedName, bool isRequiredOnCreate, bool isAllowedOnCreate, bool isRequiredOnUpdate, bool isAllowedOnUpdate, bool isRequiredOnDelete)
        {
            Name = name;
            SerializedName = serializedName;
            IsRequiredOnCreate = isRequiredOnCreate;
            IsAllowedOnCreate = isAllowedOnCreate;
            IsRequiredOnUpdate = isRequiredOnUpdate;
            IsAllowedOnUpdate = isAllowedOnUpdate;
            IsRequiredOnDelete = isRequiredOnDelete;
        }
        #endregion

        #region Methods - Interface
        private static string GenerateInvalidOperationExceptionMessage(string fieldName)
        {
            return (fieldName == null)
                ? string.Format(InvalidOperationMessageFormat, "Requested field")
                : string.Format(InvalidOperationMessageFormat, fieldName);
        }
        #endregion
    }
}