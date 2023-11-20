using DbLayer.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrder(Order order);
    }
}
