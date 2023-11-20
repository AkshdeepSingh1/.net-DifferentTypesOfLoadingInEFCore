using DbLayer.Interfaces;
using LogicLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class TryDifferentTypesOfLoadingService
    {
        private readonly ICustomerRepository customerRepository;
        public TryDifferentTypesOfLoadingService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task GetCustomerWithNoLoading(long id)
        {
            var data = await customerRepository.GetCustomerWithNoLoading(id);
        }

        public async Task GetCustomerWithEagerLoading1(long id)
        {
            var data = await customerRepository.GetCustomerWithEagerLoading1(id);
        }

        public async Task GetCustomerWithEagerLoading2(long id)
        {
            var data = await customerRepository.GetCustomerWithEagerLoading2(id);
        }

        public async Task GetCustomerWithEagerLoading3(long id)
        {
            var data = await customerRepository.GetCustomerWithEagerLoading3(id);
        }


        public async Task GetCustomerWithLazyLoading1(long id)
        {
            var data = await customerRepository.GetCustomerWithLazyLoading1(id);
            //lazy loading is designed to be transparent and non-blocking. It allows you to work with related data as if it's already loaded, and the data is fetched asynchronously when needed, without explicitly using await keyword.
            var data2 = data.Orders;
        }


        public async Task GetCustomerWithLazyLoading2(long id)
        {
            var data = await customerRepository.GetCustomerWithLazyLoading2(id);
            var data2 = data.Orders;
        }

        public async Task GetCustomerWithExplicitLoading(long id)
        {
            var data = await customerRepository.GetCustomerWithExplicitLoading(id);
            var data2 = data.Orders;
        }
    }
}
