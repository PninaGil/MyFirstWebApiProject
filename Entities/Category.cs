using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class Category
{
    public string? CategoryName { get; set; }

    public int CategoryId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
