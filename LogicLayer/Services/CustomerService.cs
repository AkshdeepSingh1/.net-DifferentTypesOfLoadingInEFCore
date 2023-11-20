using DbLayer.DbModel;
using DbLayer.Interfaces;
using DbLayer.Repositories;
using LogicLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerService(ICustomerRepository customerRepository) 
        {
            this.customerRepository = customerRepository;
        }
        public async Task<CustomerDTO> CreateCustomer(CustomerDTO customer)
        {
            var customerToSend = CustomerDTO.CustomerDTOToCustomer(customer);
            var data = await customerRepository.CreateCustomer(customerToSend);
            var dataToReturn = CustomerDTO.CustomerToCustomerDTO(data);
            return dataToReturn;
        }
    }
}
