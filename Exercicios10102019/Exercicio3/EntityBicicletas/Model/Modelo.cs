using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBicicletas.Model
{
    public class Modelo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public String Nome { get; set; }
    }
}
