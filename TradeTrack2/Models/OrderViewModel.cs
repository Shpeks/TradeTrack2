using Core.DTO;
using Core.Enum;

namespace TradeTrack2.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal Price { get; set; }

        public OrderStatus Status { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
