using Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Cities.Commands.Add;

public class CityAddCommandValidator:AbstractValidator<CityAddCommand>
{
    private readonly IApplicationDbContext _applicationDbContext;
    
    public CityAddCommandValidator(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(150);

        RuleFor(x => x.CountryId)
            .NotEmpty();

        RuleFor(x => x.CountryId)
            .MustAsync(DoesCountryExistsAsync)          //true gelirse validator kısmından geçti sayar, false gelirse kaldı sayar
            .WithMessage("The selected country does not exist.");

        RuleFor(x => x.Name)
            .MustAsync((command, name, cancellationToken) =>
            {
                return _applicationDbContext.Cities.AnyAsync(x => x.Name.ToLower() == name.ToLower(),
                    cancellationToken);
            });

        //RuleFor(x => x.CountryId).Must(IsCountryIdsValid).WithMessage("Please select at least two countries");
    }

    private Task<bool> DoesCountryExistsAsync(int countryId, CancellationToken cancellationToken)
    {
        return _applicationDbContext.Countries.AnyAsync(x => x.Id == countryId, cancellationToken);     //db de bir kayıt varsa true, yoksa false döner 
    }

    // private bool IsCountryIdsValid(List<Guid> countryIds)
    // {
    //     if (countryIds is null || !countryIds.Any() || countryIds.Count < 2) return false;
    //     return true;
    //     
    // }
}