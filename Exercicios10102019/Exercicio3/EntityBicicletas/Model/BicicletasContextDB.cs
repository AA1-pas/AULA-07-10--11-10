using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBicicletas.Model
{
    public class BicicletasContextDB : DbContext
    {
        public DbSet<Bicicleta> Bicicletas { get; set; }
    }
}
