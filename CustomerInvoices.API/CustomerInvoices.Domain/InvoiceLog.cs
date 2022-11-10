using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomerInvoices.Domain
{

    [Table(nameof(InvoiceLog))]
    public class InvoiceLog
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int InvoiceId { get; set; }

        [Required]
        public Invoice Invoice { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(4000)]
        public string Description { get; set; }
    }
}
