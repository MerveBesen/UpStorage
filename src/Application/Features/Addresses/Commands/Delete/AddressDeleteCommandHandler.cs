using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Addresses.Commands.Delete;

public class AddressDeleteCommandHandler:IRequestHandler<AddressDeleteCommand,Response<int>>
{

    private readonly IApplicationDbContext _applicationDbContext;

    public AddressDeleteCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Response<int>> Handle(AddressDeleteCommand request, CancellationToken cancellationToken)
    {
        var address = _applicationDbContext.Addresses.FirstOrDefault(x => x.Name == request.Name);
        
        address.CreatedOn = new DateTimeOffset(0,0,0,0,0,0, TimeSpan.Zero);
        address.CreatedByUserId = null;
        address.IsDeleted = true;

        await _applicationDbContext.SaveChangesAsync(cancellationToken);     //save changes çalışmadan hi biri db ye gitmez.

        return new Response<int>($"The address named \"{address.Name}\" was successfully moved deleted file.",address.Id);

    }
}