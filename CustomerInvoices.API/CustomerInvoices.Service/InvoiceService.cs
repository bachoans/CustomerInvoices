using AutoMapper;
using CustomerInvoices.Domain;
using CustomerInvoices.Models;
using CustomerInvoices.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoices.Service
{
    public class InvoiceService : BaseService, IInvoiceService
    {
        private readonly IMapper _mapper;

        public InvoiceService(CustomerInvoiceContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<InvoiceModel>> GetInvoicesAsync(int pageNumber, int pageSize)
        {
            var data = await _context.Invoices.OrderBy(x => x.Id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize).ToListAsync();

            var result = _mapper.Map<List<Invoice>, List<InvoiceModel>>(data);
            return result;
        }

        public async Task<int> CreateInvoiceAsync(InvoiceModel model)
        {
            var invoice = _mapper.Map<Invoice>(model);
            invoice.InvoiceLogs.Add(new InvoiceLog() { Date = DateTime.Now, Invoice = invoice, Description = "Invoice created" });
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice.Id;
        }

        public async Task UpdateInvoiceAsync(InvoiceModel model)
        {
            var invoice = _context.Invoices.Find(model.Id);
            invoice.Amount = model.Amount;
            invoice.CCY = model.CCY;
            invoice.Status = model.Status;
            invoice.Description = model.Description;
            invoice.DueDate = model.DueDate;

            invoice.InvoiceLogs.Add(new InvoiceLog() { Date = DateTime.Now, Invoice = invoice, Description = "Invoice updated" });
            await _context.SaveChangesAsync();
        }
    }
}