using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBNomes.Model
{
    public class Nome
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string NomeComp { get; set; }
   
    }
}
