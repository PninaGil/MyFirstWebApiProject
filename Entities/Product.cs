using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class Product
{
    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public int ProductId { get; set; }

    public int Price { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }
    [JsonIgnore]
    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
