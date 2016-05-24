namespace CloseIoDotNet.Entities.Definitions
{
    public interface IEntityQueryable : IEntity
    {
        string GenerateQueryResource(string id);
    }
}