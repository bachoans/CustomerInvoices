using System.ComponentModel.DataAnnotations;

namespace CustomerInvoices.Models
{
    public class InvoiceLogModel
    {
        public int Id { get; private set; }

        public int InvoiceId { get; private set; }

        public DateTime Date { get; private set; }

        public string? Description { get; private set; }
    }
}
