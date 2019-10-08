using ListandoDeNomes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListandoDeNomes.Controller
{
    public class NomesController
    {
        public NomeContextDB contextDb = new NomeContextDB();

        public IQueryable<NomePessoal> GetNomes ()
        {
            return contextDb.NomePessoas;
        }

        public void GetAddNomes(NomePessoal parametro)
        {
            contextDb.NomePessoas.Add(parametro);
            contextDb.SaveChanges();
        }

    }
}
