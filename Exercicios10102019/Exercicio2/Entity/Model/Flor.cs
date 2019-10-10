using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Flor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
        [Required]
        public int Quantidade { get; set; }
    }
}
