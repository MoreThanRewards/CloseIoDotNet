namespace CloseIoDotNet.Entities.Fields
{
    using System;
    using Definitions;

    public interface IEntityField<T> where T : IEntity
    {
        /// <summary>
        /// The IEntity class which contains this field.
        /// </summary>
        Type BelongsTo { get; }
        /// <summary>

        /// The name of the field in CloseIoDotNet
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The serialized name of the field used in Close.Io's API.
        /// </summary>
        string SerializedName { get; }

        /// <summary>
        /// Whether the field is required to successfully complete Close.Io POST (create) calls.
        /// </summary>
        bool IsRequiredOnCreate { get; }

        /// <summary>
        /// Whether the field is allowed in Close.Io POST (create) calls.
        /// </summary>
        bool IsAllowedOnCreate { get; }

        /// <summary>
        /// Whether the field is required to successfully complete Close.Io PUT (update) calls.
        /// </summary>
        bool IsRequiredOnUpdate { get; }

        /// <summary>
        /// Whether the field is allowed in CLose.Io PUT (update) calls.
        /// </summary>
        bool IsAllowedOnUpdate { get; }

        /// <summary>
        /// Whether the field is required to successfully complete Close.io DELETE calls.
        /// </summary>
        bool IsRequiredOnDelete { get; }
    }
}