using RevisandoEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisandoEntity.Controller
{
    public class CervejaController
    {
        CervejaContextDB contextDb = new CervejaContextDB();

        public void GetAddCerveja(Cerveja item)
        {
            if(item.Nome.Contains("Cerveja"))
            {
                contextDb.Cervejas.Add(item);
                contextDb.SaveChanges();
            }
           
        }
        public IQueryable<Cerveja> GetColCervejas()
        {
            return contextDb.Cervejas.Where(x => x.Nome.Contains("Cerveja"));
        }
    }
}
