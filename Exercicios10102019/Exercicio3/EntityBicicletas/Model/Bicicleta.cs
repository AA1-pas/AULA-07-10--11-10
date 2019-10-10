using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBicicletas.Model
{
    public class Bicicleta
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(30)]
        public string Marca { get; set; }
        [Required]
        [MaxLength(50)]
        public string Modelo { get; set; }
        [Required]
        public double Valor { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; } = true;
        public int Usuariocriacao { get; set; } = 0;
        public int UsuarioAlteracao { get; set; } = 0;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
