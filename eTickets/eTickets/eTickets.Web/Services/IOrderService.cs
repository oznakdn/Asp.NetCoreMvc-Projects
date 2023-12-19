using eTickets.Web.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Web.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAdress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);

    }
}
