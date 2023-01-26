using KarlArt.Core.Domain.Common;
using KarlArt.Core.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace KarlArt.Core.Infrastructure.Mappings;
public class CustomBsonMappings
{
    public static void Register()
    {
        // serialize guid as string
        BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(BsonType.String));
        // serialize dates as string
        BsonSerializer.RegisterSerializer(typeof(DateTime), new DateTimeSerializer(BsonType.String));
        // BsonSerializer.RegisterSerializer(typeof(DateOnly), new DateTimeSerializer(dateOnly: true, BsonType.String));
        // set up mongodb convention pack
        var pack = new ConventionPack
        {
            new EnumRepresentationConvention(BsonType.String),
            new IgnoreExtraElementsConvention(true),
            new CamelCaseElementNameConvention()
        };
        ConventionRegistry.Register("EnumStringConvention", pack, t => true);
        BsonClassMap.RegisterClassMap<BaseEntity>(cm =>
        {
            cm.AutoMap();
            cm.MapIdMember(x => x.Id).SetIdGenerator(GuidGenerator.Instance);
        });
    }
}