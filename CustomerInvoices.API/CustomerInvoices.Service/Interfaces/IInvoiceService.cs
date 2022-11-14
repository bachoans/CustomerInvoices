using CustomerInvoices.Domain;
using CustomerInvoices.Models;

namespace CustomerInvoices.Service.Interfaces
{
    public interface IInvoiceService
    {
        Task<List<InvoiceModel>> GetInvoicesAsync(int pageNumber, int pageSize);
        Task<int> CreateInvoiceAsync(InvoiceModel model);
        Task<int> UpdateInvoiceAsync(InvoiceModel model);
    }
}