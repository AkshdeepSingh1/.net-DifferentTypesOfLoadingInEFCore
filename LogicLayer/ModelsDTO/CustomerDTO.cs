using DbLayer.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ModelsDTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public static Customer CustomerDTOToCustomer(CustomerDTO customerDTO)
        {
            return new Customer()
            {
              Id = customerDTO.Id,
              Name = customerDTO.Name,
              Address = customerDTO.Address,
              City = customerDTO.City,
             };
        }

        public static CustomerDTO CustomerToCustomerDTO(Customer customer)
        {
            return new CustomerDTO()
            {
                Id = customer.Id,
                Name = customer.Name,
                Address = customer.Address,
                City = customer.City,
            };
        }
    }
}
