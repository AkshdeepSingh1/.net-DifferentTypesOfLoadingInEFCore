using DbLayer.DBContext;
using DbLayer.DbModel;
using DbLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private ApplicationDbContext db;
        public CustomerRepository(ApplicationDbContext db) 
        { 
            this.db = db;
        }
        public async Task<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                var data= await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();
                var dataToReturn = await db.Customers.Where(w => w.Id == data.Entity.Id).FirstOrDefaultAsync();
                return dataToReturn != null ? dataToReturn : new Customer();
            }
            catch (Exception ex) 
            {
                return new Customer();
            } 
        }
        ////////////////////////////////////////////// No loading -->
        public async Task<Customer> GetCustomerWithNoLoading(long id)
        {
            // This is no loading, so whenever we will fetch data it wont bring the related tables with it.
            var data =  await db.Customers.FindAsync((int)id);
            return data;
        }
        //////////////////////////////////////////////Eager loading -->

        //In this type of loading we can bring the related data with in just one sql query. All the related data will come as a result of 1 sql query. 
        // Note: If the data is in large quantity and by bringing related data as well, we may be putting a lots of load on one query making it very slow which will make our whole api slow.
        public async Task<Customer> GetCustomerWithEagerLoading1(long id)
        {
            // This is Eager loading, so whenever we will fetch data it will bring the related table(Orders Table) with it.
            // In this case just the related entity will be fetched i.e Orders. Note that invoice in Order will not be fetched because invoice table is not called as of now.
            var data = await db.Customers.Include(i => i.Orders).Where(w => w.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Customer> GetCustomerWithEagerLoading2(long id)
        {
            // This is Eager loading, so whenever we will fetch data it will bring the related table(Orders Table) with it.
            // In this case just the related entity will be fetched i.e Orders and with orders Invoice will also be fetched because we are calling that relaed entity.
            var data = await db.Customers.Include(i => i.Orders).ThenInclude(i => i.Invoice).Where(w => w.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Customer> GetCustomerWithEagerLoading3(long id)
        {
            // This is no loading, so whenever we will fetch data it wont bring the related tables with it
            // In this case just the related entity will be fetched i.e Orders and with orders Invoice will also be fetched but on the condition mentioned
            // So if we want that the related data should be fetched based on condition that is also possible. Helping us to fetch the data that is neccassary
            var data = await db.Customers.Include(i => i.Orders.Where(w => w.Id > 1)).Where(w => w.Id == id).FirstOrDefaultAsync();
            return data;
        }

        ////////////////////////////////////////////////Lazy Loading -->
        //In this type of loading we can bring the related data with multiple sql queries. All the related data will come on the time when we need it.
        // Note: if the items to fetch are a lot and we are iterating them later one by one then n + 1 sql query will be hited and will take a lot of time, use eager loading in that case bring data in one go.
        public async Task<Customer> GetCustomerWithLazyLoading1(long id)
        {
            // This is lazy loading, so whenever we will fetch data it will not bring the related table/entities with it.
            // It will load those related entites whenever they are used of whenever we access them. So only the right data will be fetched but in case of lazy loading n+1 sql calls are made (make sure of this cause if a lot of sql calls are made it will slow the process)
            var data = await db.Customers.Where(w => w.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task<Customer> GetCustomerWithLazyLoading2(long id)
        {
            // We still can overide lazy loading by writing normal implementation of eager loading even if all the conditions for lazy loading are true and even if the project is configured for lazy loading.
            var data = await db.Customers.Include(i => i.Orders).Where(w => w.Id == id).FirstOrDefaultAsync();
            return data;
        }

        ////////////////////////////////////////////////Explicit Loading -->

        public async Task<Customer> GetCustomerWithExplicitLoading(long id)
        {
            var data = await db.Customers.Where(w => w.Id == id).FirstOrDefaultAsync();
            db.Entry(data).Collection(x => x.Orders).Load();
            return data;
        }
    }
}
