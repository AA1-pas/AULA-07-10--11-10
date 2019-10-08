using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListandoDeNomes.Model
{
    public class NomeContextDB :DbContext
    {
        public DbSet<NomePessoal> NomePessoas { get; set; }
    }
}
