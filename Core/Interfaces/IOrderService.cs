using Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<OrderDTO> GetAllOrder();

        OrderDTO GetOrderById(int id);

        int CreateOrder();

        void UpdateOrder(OrderDTO orderDTO);

        Task DeleteOrderAsync(int id);
    }
}
