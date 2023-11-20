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
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext db;
        public InvoiceRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
            var data = await db.Invoices.AddAsync(invoice);
            await db.SaveChangesAsync();
            var dataToReturn = await db.Invoices.Where(s => s.Id == data.Entity.Id).FirstOrDefaultAsync();
            return dataToReturn;
        }
    }
}
