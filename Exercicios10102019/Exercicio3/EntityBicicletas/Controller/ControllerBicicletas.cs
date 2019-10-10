using EntityBicicletas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityBicicletas.Controller
{
    public class ControllerBicicletas
    {
        BicicletasContextDB bicicletas = new BicicletasContextDB();

        public bool AddBicicleta(Bicicleta item)
        {
            if (item == null)
                return false;
            bicicletas.Bicicletas.Add(item);
            bicicletas.SaveChanges();
            return true;
        }

        public bool DelBicicleta( int id)
        {
            var item = bicicletas.Bicicletas.FirstOrDefault(x => x.ID == id && x.Ativo == true);
            if (item == null)
                return false;
            item.Ativo = false;
            bicicletas.SaveChanges();
            return true;
        }

        public IQueryable<Bicicleta> GetBicicletas()
        {
            return bicicletas.Bicicletas;
        }

        public bool AtuBicicleta(Bicicleta item)
        {
            var resu = bicicletas.Bicicletas.FirstOrDefault(x => x.ID == item.ID && x.Ativo == true);
            if (resu == null)
                return false;
            bicicletas.SaveChanges();
            return true;
        }
    }
}
