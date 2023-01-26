using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarlArt.Core.Application.Common.Interfaces.Settings;

namespace KarlArt.Core.Infrastructure.Settings;
public class MongoDbSettings : IMongoDbSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
    public bool UseInMemoryDatabase { get; set; }
}