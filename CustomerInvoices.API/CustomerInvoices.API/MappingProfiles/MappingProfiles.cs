using AutoMapper;
using CustomerInvoices.Models;
using CustomerInvoices.Domain;

namespace CustomerInvoices.API.MappingProfiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Invoice, InvoiceModel>().ReverseMap().ForMember(x => x.InvoiceLogs, x => x.Ignore());
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<InvoiceLog, InvoiceLogModel>().ReverseMap();
        }
    }
}