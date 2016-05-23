namespace CloseIoDotNet.Rest.Utilities
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Fields;

    public interface IFieldsParameterValueFactory
    {
        string Create(IEnumerable<IEntityField> fields);
    }
}