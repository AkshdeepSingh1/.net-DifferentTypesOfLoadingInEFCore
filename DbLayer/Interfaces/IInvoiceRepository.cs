﻿using DbLayer.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateInvoice(Invoice invoice);
    }
}
