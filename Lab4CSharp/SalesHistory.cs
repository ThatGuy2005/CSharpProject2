using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    public class IstoricVanzari
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdProdus { get; set; }
        [Required]
        public int Cantitate { get; set; }
    }
}
