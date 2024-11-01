using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Models
{
    [Table("COM_CUSTOMER")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int COM_CUSTOMER_ID { get; set; }

        [StringLength(100)]
        public string CUSTOMER_NAME { get; set; } 

    }
}
