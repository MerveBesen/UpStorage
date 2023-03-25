using Domain.Common;

namespace Domain.Entities;

public class Category:IEntityBase<Guid>
{
    public string Name { get; set; }
}