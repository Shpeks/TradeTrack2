using Core.DTO;
using TradeTrack2.Models;

namespace TradeTrack2.Mapping
{
    public static class OrderToDTO
    {
        public static OrderDTO GetOrderDTO(this OrderViewModel model)
        {
            var order = new OrderDTO
            {
                Id = model.Id,
                OrderDate = model.OrderDate,
                Price = model.Price,
            };

            return order;
        }
    }
}
