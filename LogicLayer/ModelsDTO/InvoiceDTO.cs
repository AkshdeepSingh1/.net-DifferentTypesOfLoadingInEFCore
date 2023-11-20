using DbLayer.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.ModelsDTO
{
    public class InvoiceDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }


        public static Invoice InvoiceDTOToInvoice(InvoiceDTO invoiceDto)
        {
            return new Invoice()
            {
                Id = invoiceDto.Id,
                OrderId = invoiceDto.OrderId,
                Price = invoiceDto.Price,
                CreatedAt = invoiceDto.CreatedAt,
            };
        }

        public static InvoiceDTO InvoicetoInvoiceDTO(Invoice invoice)
        {
            return new InvoiceDTO()
            {
                Id = invoice.Id,
                OrderId = invoice.OrderId,
                Price = invoice.Price,
                CreatedAt = invoice.CreatedAt,
            };
        }
    }
}
