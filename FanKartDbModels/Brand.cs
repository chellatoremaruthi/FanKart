﻿using System;
using System.Collections.Generic;

namespace FanKart.FanKartDbModels
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
