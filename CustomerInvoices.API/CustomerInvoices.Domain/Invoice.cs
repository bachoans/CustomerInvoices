using CustomerInvoices.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerInvoices.Domain
{
    [Table(nameof(Invoice))]
    public class Invoice
    {
        public Invoice()
        {
            InvoiceLogs = new HashSet<InvoiceLog>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public virtual Customer Customer { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public InvoiceStatusType Status { get; set; }

        [Required]
        [StringLength(3)]
        public string CCY { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(4000)]
        public string Description { get; set; }

        public virtual ICollection<InvoiceLog> InvoiceLogs { get; set; }
    }
}
