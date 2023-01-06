using System.Security.AccessControl;
using Domain.Entities.Base;
using Domain.Entities.Identity;

namespace Domain.Entities.ProductEntity;

public class ProductBrand : BaseAuditableEntity, ICommands
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string Summary { get; set; }
    public User User { get; set; }
}