using Application.Common.Interfaces;
using Application.Common.Models.General;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Features.Countries.Queries.GetAll;

public class CountriesGetAllQueryHandler:IRequestHandler<CountriesGetAllQuery,PaginatedList<CountriesGetAllDto>>
{

    private readonly IApplicationDbContext _applicationDbContext;

    private readonly IMemoryCache _memoryCache;

    private const string CountriesKey = "CountriesList";

    private readonly MemoryCacheEntryOptions _cacheOptions;
    
    public CountriesGetAllQueryHandler(IApplicationDbContext applicationDbContext, IMemoryCache memoryCache)
    {
        _applicationDbContext = applicationDbContext;
        
        _memoryCache = memoryCache;
        
        _cacheOptions = new MemoryCacheEntryOptions()
        {
            Priority = CacheItemPriority.Normal,
            AbsoluteExpiration = DateTimeOffset.Now.AddHours(6)
        };
    }

    public async Task<PaginatedList<CountriesGetAllDto>> Handle(CountriesGetAllQuery request, CancellationToken cancellationToken)
    {

        if (_memoryCache.TryGetValue(CountriesKey, out List<CountriesGetAllDto> countries)) //Memorycacheden değeri getirmeye calış getirebiliyorsan verilen değişkene ata.
        {
            //if (countries is not null && countries.Any())
                return PaginatedList<CountriesGetAllDto>.Create(countries,request.PageNumber,request.PageSize);
        }

        var countryDtos = await _applicationDbContext.Countries
            .Select(x => new CountriesGetAllDto(x.Id, x.Name))
            .AsTracking()
            .ToListAsync(cancellationToken);

        
        _memoryCache.Set(CountriesKey, countries, _cacheOptions);

        return PaginatedList<CountriesGetAllDto>.Create(countryDtos,request.PageNumber,request.PageSize);

    }
}