using Application.Common.Interfaces;
using Application.Common.Models.Address;
using Domain.Common;
using Domain.Entities;
using MediatR;

namespace Application.Features.Addresses.Commands.Add;

public class AddressAddCommandHandler:IRequestHandler<AddressAddCommand,Response<int>>
{

    private readonly IApplicationDbContext _applicationDbContext;

    public AddressAddCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Response<int>> Handle(AddressAddCommand request, CancellationToken cancellationToken)
    {
        var address = new Address()
        {
            Name = request.Name,
            UserId = request.UserId,
            CountryId = request.CountryId,
            CityId = request.CityId,
            District = request.District,
            PostCode = request.PostCode,
            AddressLine1 = request.AddressLine1,
            AddressLine2 = request.AddressLine2,
            CreatedOn = DateTimeOffset.Now,
            CreatedByUserId = null,
            IsDeleted = false,
            AddressType = AddressTypeDto.ConvertToAddressType(request.AddressTypeName.ToLower()),
        };
        await _applicationDbContext.Addresses.AddAsync(address, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);     //save changes çalışmadan hi biri db ye gitmez.

        return new Response<int>($"The new address named \"{address.Name}\" was successfully added.",address.Id);

    }
}