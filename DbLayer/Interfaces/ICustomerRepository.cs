using DbLayer.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> CreateCustomer(Customer customer);
        Task<Customer> GetCustomerWithNoLoading(long id);
        Task<Customer> GetCustomerWithEagerLoading1(long id);
        Task<Customer> GetCustomerWithEagerLoading2(long id);
        Task<Customer> GetCustomerWithEagerLoading3(long id);
        Task<Customer> GetCustomerWithLazyLoading1(long id);
        Task<Customer> GetCustomerWithLazyLoading2(long id);
        Task<Customer> GetCustomerWithExplicitLoading(long id);
    }
}
