using Core.DTO;
using Core.Entities;
using Core.Enum;
using Core.Interfaces;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int CreateOrder()
        {
            using var tr = _context.Database.BeginTransaction();
            try
            {
                var order = new Order
                {
                    OrderDate = DateTime.Now,
                    Status = OrderStatus.Waiting,
                    Price = 0

                };

                _context.Orders.Add(order);
                _context.SaveChanges();

                tr.Commit();

                return order.Id;
            }
            catch (Exception ex)
            {
                tr.Rollback();
                throw;
            }
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public IEnumerable<OrderDTO> GetAllOrder()
        {
            return _context.Orders.Select(o => new OrderDTO
            {
                Id = o.Id,
                OrderDate = o.OrderDate,
                Status = o.Status,
                Price = o.Price,
            }).ToList();
        }

        public OrderDTO GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return null;

            return new OrderDTO
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                Status = order.Status,
                Price = order.Price,
            };
        }

        public void UpdateOrder(OrderDTO orderDTO)
        {
            var order = _context.Orders.Find(orderDTO.Id);
            if (order == null) return;

            order.OrderDate = orderDTO.OrderDate;
            order.Status = orderDTO.Status;
            order.Price = orderDTO.Price;

            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
