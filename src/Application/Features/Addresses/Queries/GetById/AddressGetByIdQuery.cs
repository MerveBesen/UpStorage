using Application.Features.Addresses.Queries.GetAll;
using MediatR;

namespace Application.Features.Addresses.Queries.GetById;

public class AddressGetByIdQuery:IRequest<List<AddressGetByIdDto>>
{
    public int Id { get; set; }
    
    public bool? IsDeleted { get; set; }

    public AddressGetByIdQuery(int id, bool? isIsDeleted)
    {
        Id = id;

        IsDeleted = isIsDeleted;
    }
}