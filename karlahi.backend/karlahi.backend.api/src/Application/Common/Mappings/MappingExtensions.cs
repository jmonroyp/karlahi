using AutoMapper;

namespace KarlArt.Core.Application.Common.Mappings;

public static class MappingExtensions
{
    public static List<TDestination> MapList<TSource, TDestination>(this IMapper mapper, IEnumerable<TSource> source) =>
        mapper.Map<List<TDestination>>(source);
}