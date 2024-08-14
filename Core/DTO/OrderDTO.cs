﻿using Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
    
        public DateTime OrderDate { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
