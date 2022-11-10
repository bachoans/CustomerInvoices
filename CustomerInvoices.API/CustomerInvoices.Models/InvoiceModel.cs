using CustomerInvoices.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace CustomerInvoices.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public InvoiceStatusType Status { get; set; }

        [Required]
        public string CCY { get; set; }

        [Required]
        [Range(0.01d, 1_000_000_000)]
        public decimal Amount { get; set; }

        public string Description { get; set; }
    }
}