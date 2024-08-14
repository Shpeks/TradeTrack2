using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using TradeTrack2.Extensions;

namespace TradeTrack2.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orderDto = _orderService.GetAllOrder();
            var orderViewModel = orderDto
                .Select(dto => dto.GetOrderViewModel())
                .ToList();

            return View(orderViewModel);
        }
    }
}
