namespace KarlArt.Core.Application.Common.Interfaces.Settings;
public interface IMongoDbSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
    bool UseInMemoryDatabase { get; set; }
}