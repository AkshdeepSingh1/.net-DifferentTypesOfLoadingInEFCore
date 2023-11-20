using LogicLayer.ModelsDTO;
using LogicLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace DifferentTypesOfLoadingInDotNetCore.Controllers
{

    [ApiController]
    [Route("api /[Controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceService invoiceService;
        public InvoiceController(InvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateInvoice(InvoiceDTO invoiceDTO)
        {
            var data = await invoiceService.CreateInvoice(invoiceDTO);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
