using Azure.Storage.Blobs;
using KarlArt.Core.Application.Common.Interfaces.Repositories;
using KarlArt.Core.Application.Common.Interfaces.Services;
using KarlArt.Core.Infrastructure.Mappings;
using KarlArt.Core.Infrastructure.Repositories;
using KarlArt.Core.Infrastructure.Services;
using KarlArt.Core.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Mongo2Go;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Core.Events;
using Openpay;

namespace Microsoft.Extensions.DependencyInjection;
public static class ConfigureServices
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, WebApplicationBuilder builder, ILogger logger)
    {
        var configuration = builder.Configuration;
        var mongodbSettings = configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>() ?? default!;
        services.AddSingleton(mongodbSettings);
        var azureStorageSettings = configuration.GetSection("AzureStorageSettings").Get<AzureStorageSettings>() ?? default!;
        services.AddSingleton(azureStorageSettings);


        MongoClient mongoClient = default!;
        if (mongodbSettings.UseInMemoryDatabase)
        {
            var runner = MongoDbRunner.Start();
            mongoClient = new MongoClient(runner.ConnectionString);
            services.AddSingleton(runner);
        }
        else {
            var mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(mongodbSettings.ConnectionString));
            mongoClientSettings.ClusterConfigurator = cb =>
            {
                cb.Subscribe<CommandStartedEvent>(e =>
                {
                    // log query
                    var query = e.Command.ToJson();
                    logger.LogInformation($"CommandName: {e.CommandName} Query: {query}");
                });
            };
            mongoClient = new MongoClient(mongoClientSettings);
        }
        services.AddScoped<IMongoClient>(sp => mongoClient);
        services.AddScoped<IMongoDatabase>(sp => mongoClient.GetDatabase(mongodbSettings.DatabaseName));
        CustomBsonMappings.Register();


        services.AddRepositories();
        services.AddCloudServices();
        services.AddPaymentServices();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPatientRepository, PatientRepository>();
        services.AddScoped<IAttachmentRepository, AttachmentRepository>();
        services.AddScoped<IOdontogramNoteRepository, OdontogramNoteRepository>();
        services.AddScoped<IEvolutionNoteRepository, EvolutionNoteRepository>();

        //KarlaArt.Core.Application.Common.Interfaces.Repositories
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        return services;
    }

    private static IServiceCollection AddCloudServices(this IServiceCollection services)
    {
        // inject BlobServiceClient from Azure.Storage.Blobs
        services.AddScoped<BlobServiceClient>(sp =>
        {
            var azureStorageSettings = sp.GetRequiredService<AzureStorageSettings>();
            return new BlobServiceClient(azureStorageSettings.ConnectionString);
        });
        // add azure storage services
        services.AddScoped<IStorageService, AzureStorageService>();
        
        
        return services;
    }

    private static IServiceCollection AddPaymentServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(OpenpayAPI), sp =>
        {
            var openPaySettings = sp.GetRequiredService<OpenPaySettings>();
            return new OpenpayAPI(openPaySettings.MerchantId, openPaySettings.PrivateKey, false);
        });
        services.AddScoped<IPaymentService, OpenPayService>();
        return services;
    }
}


internal static class MongoExtensions {

    public static string ToJson(this BsonDocument document) {
        return document.ToJson(new JsonWriterSettings { OutputMode = JsonOutputMode.CanonicalExtendedJson });
    }  
}
