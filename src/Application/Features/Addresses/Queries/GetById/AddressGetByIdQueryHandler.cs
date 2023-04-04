using Application.Common.Interfaces;
using Application.Features.Addresses.Queries.GetAll;
using MediatR;

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
        throw new NotImplementedException();
    }
}