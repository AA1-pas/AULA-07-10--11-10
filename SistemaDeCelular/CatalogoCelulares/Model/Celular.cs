using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoCelulares.Model
{
    public class Celular : ControleUsuario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Marca { get; set; }
        [Required]
        [MaxLength(30)]
        public string Modelo { get; set; }
        public double Preco { get; set; } 
    }
}
