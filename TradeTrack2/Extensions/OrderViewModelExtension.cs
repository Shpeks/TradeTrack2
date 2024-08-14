using Core.DTO;
using TradeTrack2.Models;

namespace TradeTrack2.Extensions
{
    public static class OrderViewModelExtension
    {
        public static OrderViewModel GetOrderViewModel(this OrderDTO model)
        {
            var order = new OrderViewModel
            {
                Id = model.Id,
                OrderDate = model.OrderDate,
                Price = model.Price,
            };

            return order;
        }
    }
}
