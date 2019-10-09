using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoCelulares.Model
{
    public class Usuario : ControleUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Nome { get; set; }
        [Required]
        [MaxLength(30)]
        public string Login { get; set; }
        [Required]
        [MaxLength(30)]
        public string Senha { get; set; }

    }
}
