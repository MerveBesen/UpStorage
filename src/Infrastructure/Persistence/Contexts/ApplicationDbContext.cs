using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Contexts;

public class ApplicationDbContext : DbContext,IApplicationDbContext
{
    private IApplicationDbContext _applicationDbContextImplementation;
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<City> Cities { get; set; }
    
    public DbSet<Address> Addresses { get; set; }
    
    public DbSet<Note> Notes { get; set; }
    public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}