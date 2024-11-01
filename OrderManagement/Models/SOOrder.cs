using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagement.Models
{
    [Table("SO_ORDER")]
    public class SOOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long SO_ORDER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string ORDER_NO { get; set; }

        [Required]
        public DateTime ORDER_DATE { get; set; }

        [Required]
        public int COM_CUSTOMER_ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ADDRESS { get; set; }

        // // Relasi ke Customer
        // [ForeignKey("COM_CUSTOMER_ID")]
        // public Customer Customer { get; set; }

        // Relasi ke SOItem
        public ICollection<SOItem> Items { get; set; }
    }
    
}
