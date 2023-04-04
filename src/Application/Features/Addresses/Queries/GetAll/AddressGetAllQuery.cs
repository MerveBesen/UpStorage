using MediatR;

namespace Application.Features.Addresses.Queries.GetAll;

public class AddressGetAllQuery:IRequest<List<AddressGetAllDto>>
{
    public int CountryId { get; set; }
    public bool? IsDeleted { get; set; }

    public AddressGetAllQuery(int countryId,int cityId,bool? isDeleted)
    {
        CountryId = countryId;

        IsDeleted = isDeleted;
    }
}