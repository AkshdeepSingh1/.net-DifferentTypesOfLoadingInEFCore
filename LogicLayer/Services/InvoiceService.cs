using DbLayer.Interfaces;
using LogicLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Services
{
    public class InvoiceService
    {
        private IInvoiceRepository invoiceRepository;
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            this.invoiceRepository = invoiceRepository;
        }
        public async Task<InvoiceDTO> CreateInvoice(InvoiceDTO invoiceDTO)
        {
            var invoiceToSend = InvoiceDTO.InvoiceDTOToInvoice(invoiceDTO);
            var data = await invoiceRepository.CreateInvoice(invoiceToSend);
            var dataToReturn = InvoiceDTO.InvoicetoInvoiceDTO(data);
            return dataToReturn;
        }
    }
}
