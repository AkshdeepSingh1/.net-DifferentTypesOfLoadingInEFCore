using Azure.Core;
using DbLayer.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ModelsDTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }

        public static Order OrderDTOToOrder(OrderDTO orderDto)
        {
            return new Order()
            {
                Description = orderDto.Description,
                CustomerId = orderDto.CustomerId,
            };
        }

        public static OrderDTO OrdertoOrderDTO(Order order)
        {
            return new OrderDTO()
            {
                Id = order.Id,
                Description = order.Description,
                CustomerId = order.CustomerId,
            };
        }
    }
 
}
