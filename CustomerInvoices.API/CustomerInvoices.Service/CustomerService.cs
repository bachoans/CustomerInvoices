using AutoMapper;
using CustomerInvoices.Domain;
using CustomerInvoices.Models;
using CustomerInvoices.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerInvoices.Service
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly IMapper _mapper;

        public CustomerService(CustomerInvoiceContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<CustomerModel>> GetCustomersAsync(int pageNumber, int pageSize)
        {
            try
            {
                var data = await _context.Customers.OrderBy(x => x.Id)
                        .Skip(pageNumber * pageSize)
                        .Take(pageSize).ToListAsync();
                var result = _mapper.Map<List<CustomerModel>>(data);
                return result;
            }
            catch (Exception)
            {
                //TODO:log exception
                throw;
            }
        }
    }
}