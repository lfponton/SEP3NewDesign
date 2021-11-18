using System.Collections.Generic;
using System.Threading.Tasks;

using WebClient.Models;

namespace WebClient.Data
{
    public interface IInfoService
    {
        Task<Address> AddInfoOrderAsync(Address infoOrder);
        Task<List<OrderItem>> GetOrderItems(OrderItem orderItems);


    }
}