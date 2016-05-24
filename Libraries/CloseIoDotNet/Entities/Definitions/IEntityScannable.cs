namespace CloseIoDotNet.Entities.Definitions
{
    using System.Collections.Generic;
    using CloseIoDotNet.Entities.Enumerations;
    using Fields;

    public interface IEntityScannable : IEntity
    {
        IEnumerable<IEntityField> ScannableFields { get; }
        IEnumerable<ScanType> ScanTypesSupported { get; }
        string GenerateScanResource();
    }
}