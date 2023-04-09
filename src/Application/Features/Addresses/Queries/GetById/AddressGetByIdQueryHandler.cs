using Application.Common.Interfaces;
using Application.Common.Models.Address;
using Application.Features.Addresses.Queries.GetAll;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Queries.GetById;

public class AddressGetByIdQueryHandler:IRequestHandler<AddressGetByIdQuery,List<AddressGetByIdDto>>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public AddressGetByIdQueryHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<AddressGetByIdDto>> Handle(AddressGetByIdQuery request, CancellationToken cancellationToken)
    {
        var dbQuery = _applicationDbContext.Addresses.AsQueryable();

        dbQuery = dbQuery.Where(x => x.Id == request.Id);

        if (request.IsDeleted.HasValue) dbQuery = dbQuery.Where(x => x.IsDeleted == request.IsDeleted.Value);
        
        dbQuery = dbQuery.Include(x => x.Country);
        dbQuery = dbQuery.Include(x => x.City);
        
        var addresses = await dbQuery.ToListAsync(cancellationToken);

        var addressDtos = MapAddressesToGetByIdDtos(addresses);

        return addressDtos.ToList();
    }

    private IEnumerable<AddressGetByIdDto> MapAddressesToGetByIdDtos(List<Address> addresses)
    {
        List<AddressGetByIdDto> addressGetByIdDtos = new List<AddressGetByIdDto>();

        foreach (var address in addresses)
        {
            yield return new AddressGetByIdDto
            {
                Id = address.Id,
                CountryId = address.CountryId,
                CountryName = address.Country.Name,
                CityId = address.CityId,
                CityName = address.City.Name,
                District = address.District,
                PostCode = address.PostCode,
                Name = address.Name,
                UserId = address.UserId,
                UserName = address.User.FirstName,
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                IsDeleted = address.IsDeleted,
                AddressTypeName = AddressTypeDto.ConvertToAddressTypeName(address.AddressType),

            };
        }
    }
}