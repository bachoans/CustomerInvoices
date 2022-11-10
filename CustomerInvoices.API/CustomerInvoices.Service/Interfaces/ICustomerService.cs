using CustomerInvoices.Domain;
using CustomerInvoices.Models;

namespace CustomerInvoices.Service.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerModel>> GetCustomersAsync(int pageNumber, int pageSize);
    }
}
