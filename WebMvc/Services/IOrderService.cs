using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models.OrderModels;

namespace WebMvc.Services
{
   public interface IOrderService
    {


        Task<List<Order>> GetOrdersAsync();
        //Task<List<Order>> GetOrdersByUser(ApplicationUser user);
        Task<Order> GetOrderAsync(string orderId);
        Task<int> CreateOrderAsync(Order order);
        //  Order MapUserInfoIntoOrder(ApplicationUser user, Order order);
        //  void OverrideUserInfoIntoOrder(Order original, Order destination);
    }
}
