using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBicicletas.Model
{
    public class Bicicleta
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Marca")]
        public int MarcaID { get; set; }
        public virtual Marca Marca { get; set; }
        [ForeignKey("Modelo")]
        public int ModeloID { get; set; }
        public virtual Modelo Modelo { get; set; }
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
