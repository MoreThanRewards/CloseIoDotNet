namespace CloseIoDotNet.Rest.Utilities
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CloseIoDotNet.Entities.Fields;

    public class FieldsParameterValueFactory : IFieldsParameterValueFactory
    {
        public string Create(IEnumerable<IEntityField> fields)
        {
            if (fields == null || fields.Any() == false)
            {
                return string.Empty;
            }

            var stringBuilder = new StringBuilder();
            foreach (var field in fields)
            {
                if (stringBuilder.Length != 0)
                {
                    stringBuilder.Append(',');
                }
                stringBuilder.Append(field.SerializedName);
            }

            var result = stringBuilder.ToString();

            return result;

        }
    }
}