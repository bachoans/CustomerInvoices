using AutoMapper;
using CustomerInvoices.Domain;
using CustomerInvoices.Models;
using CustomerInvoices.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoices.Service;
public class InvoiceService : BaseService, IInvoiceService
{
    private readonly IMapper _mapper;

    public InvoiceService(CustomerInvoiceContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Get all invoice
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns>Invoice list</returns>
    public async Task<List<InvoiceModel>> GetInvoicesAsync(int pageNumber, int pageSize)
    {
        try
        {
            var data = await _context.Invoices.OrderBy(x => x.Id)
                .Skip(pageNumber * pageSize)
                .Take(pageSize).ToListAsync();
            var result = _mapper.Map<List<Invoice>, List<InvoiceModel>>(data);
            return result;
        }
        catch (Exception)
        {
            //TODO:log exception
            throw;
        }
    }

    /// <summary>
    /// Create invoice
    /// </summary>
    /// <param name="model">Invoice Model</param>
    /// <returns>Created invoice Id</returns>
    public async Task<int> CreateInvoiceAsync(InvoiceModel model)
    {
        try
        {
            var invoice = _mapper.Map<Invoice>(model);
            invoice.InvoiceLogs.Add(new InvoiceLog() { Date = DateTime.Now, Invoice = invoice, Description = "Invoice created" });
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice.Id;
        }
        catch (Exception)
        {
            //TODO:log exception
            throw;
        }
    }

    /// <summary>
    /// Update invoice
    /// </summary>
    /// <param name="model">Invoice Model</param>
    /// <returns></returns>
    public async Task<int> UpdateInvoiceAsync(InvoiceModel model)
    {
        try
        {
            var invoice = _context.Invoices.Find(model.Id);
            if (invoice != null)
            {
                invoice.Amount = model.Amount;
                invoice.CCY = model.CCY;
                invoice.Status = model.Status;
                invoice.Description = model.Description;
                invoice.DueDate = model.DueDate;
            }
            invoice.InvoiceLogs.Add(new InvoiceLog() { Date = DateTime.Now, Invoice = invoice, Description = "Invoice updated" });
            await _context.SaveChangesAsync();
            return invoice.Id;
        }
        catch (Exception)
        {
            //TODO:log exception
            throw;
        }
    }
}