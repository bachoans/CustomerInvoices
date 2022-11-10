using CustomerInvoices.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInvoices.Service
{
    public abstract class BaseService
    {
        protected readonly CustomerInvoiceContext _context;
        public BaseService(CustomerInvoiceContext context)
        {
            _context = context;
        }
    }
}