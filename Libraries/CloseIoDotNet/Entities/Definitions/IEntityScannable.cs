namespace CloseIoDotNet.Entities.Definitions
{
    public interface IEntityScannable : IEntity
    {
        string GenerateScanResource();
    }
}