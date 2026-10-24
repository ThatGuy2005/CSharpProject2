using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    [Table("Categories")]
    public class CategorieProdus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Denumire { get; set; }

        public override string ToString()
        {
            return Denumire;
        }
    }
}
