using CustomerInvoices.Models;
using CustomerInvoices.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInvoices.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvoiceController : Controller
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("List")]
        public async Task<JsonResult> List(int page, int pageSize)
        {
            var result = await _invoiceService.GetInvoicesAsync(page, pageSize);

            return Json(result);
        }

        [HttpPost("Create")]
        public async Task<JsonResult> Create(InvoiceModel model)
        {
            var result = await _invoiceService.CreateInvoiceAsync(model);
            return Json(result);
        }

        [HttpPut("Update")]
        public async Task Update(InvoiceModel model)
        {
            await _invoiceService.UpdateInvoiceAsync(model);
        }
    }
}