using Domain.Entities.Base;

namespace Domain.Entities.ProductEntity;

public class ProductType : BaseAuditableEntity, ICommands
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    public string Summary { get; set; }
}