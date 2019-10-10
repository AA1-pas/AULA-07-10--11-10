using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Controller
{
    public class ControllerFlores
    {
        FloresConextDB contextDB = new FloresConextDB();

        public IQueryable<Flor> GetFlores()
        {
            return contextDB.Flores;
        }

        public bool AddFlor(Flor item)
        {
            if (item == null)
                return false;
            contextDB.Flores.Add(item);
            contextDB.SaveChanges();
            return true;
        }



    }
}
