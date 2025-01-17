﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        /// <summary>
        /// Цена за единицу
        /// </summary>
        public decimal UnitPrice { get; set; }

        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
