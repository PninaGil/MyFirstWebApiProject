

namespace Entities;

public partial class Category
{
    public string? CategoryName { get; set; }

    public int CategoryId { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
