using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Models
{
    [Table("SO_ITEM")]
    public class SOItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SO_ITEM_ID { get; set; }

        [Required]
        public long SO_ORDER_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ITEM_NAME { get; set; }

        [Required]
        public int QUANTITY { get; set; }

        [Required]
        public double PRICE { get; set; }

    }
    
}
