using System.ComponentModel.DataAnnotations;

namespace CustomerInvoices.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        public string Firstname { get; private set; }

        [Required]
        public string Lastname { get; private set; }
    }
}