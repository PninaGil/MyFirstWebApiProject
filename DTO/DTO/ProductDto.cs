﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public string ProductName { get; set; }

        public int CategoryName { get; set; }

        public int ProductId { get; set; }

        public int Price { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }
    }
}
