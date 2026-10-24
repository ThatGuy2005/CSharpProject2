using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    [Table("Products")]
    public class Products
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(30)]
        public string ProductName { get; set; }
        [MaxLength(500)]
        public string ProductDescription { get; set; }
        public DateTime StoreEntryDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Quantity { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
