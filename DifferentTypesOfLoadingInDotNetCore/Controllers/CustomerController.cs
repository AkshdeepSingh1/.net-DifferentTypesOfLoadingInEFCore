using LogicLayer.ModelsDTO;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DifferentTypesOfLoadingInDotNetCore.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customerService;
        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CustomerDTO customer)
        {
            var data =  await customerService.CreateCustomer(customer);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
