using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLayer.Interfaces;
using DbLayer.Repositories;
using LogicLayer.ModelsDTO;

namespace LogicLayer.Services
{
    public class OrderService
    {
        private IOrderRepository orderRepository;
        public OrderService(IOrderRepository orderRepository) 
        {
            this.orderRepository = orderRepository;
        }
        public async Task<OrderDTO> CreateOrder(OrderDTO orderDTO)
        {
            var orderToSend = OrderDTO.OrderDTOToOrder(orderDTO);
            var data = await orderRepository.CreateOrder(orderToSend);
            var dataToReturn =  OrderDTO.OrdertoOrderDTO(data);
            return dataToReturn;
        }
    }
}
