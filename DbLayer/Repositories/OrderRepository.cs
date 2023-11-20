using DbLayer.DBContext;
using DbLayer.DbModel;
using DbLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace DbLayer.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly ApplicationDbContext db;
        public OrderRepository(ApplicationDbContext db)
        {
            this.db = db;   
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var data = await db.Orders.AddAsync(order);
            await db.SaveChangesAsync();
            var dataToReturn = await db.Orders.Where(s => s.Id == data.Entity.Id).FirstOrDefaultAsync();
            return dataToReturn;
        }
    }
}
