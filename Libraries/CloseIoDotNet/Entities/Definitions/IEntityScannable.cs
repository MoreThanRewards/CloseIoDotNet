namespace CloseIoDotNet.Entities.Definitions
{
    using System.Collections.Generic;
    using Fields;

    public interface IEntityScannable : IEntity
    {
        IEnumerable<IEntityField> ScannableFields { get; }
        string GenerateScanResource();
    }
}