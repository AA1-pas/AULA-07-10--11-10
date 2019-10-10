using DBNomes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBNomes.Controller
{
    public class ControllerNomes
    {
        NomesContextDB nomes = new NomesContextDB();

        public IQueryable<Nome> GetNomes()
        {
            return nomes.Nomes;
        }

        public bool AddNomes(Nome item)
        {
            if (item == null)
                return false;
            nomes.Nomes.Add(item);
            nomes.SaveChanges();
            return true;
        }
    }
}
