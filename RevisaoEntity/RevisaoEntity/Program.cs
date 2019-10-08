using RevisandoEntity.Controller;
using RevisandoEntity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacaoVisual
{
    class Program
    {
        static CervejaController contextDB = new CervejaController();
        static void Main(string[] args)
        {
            contextDB.GetAddCerveja(new Cerveja() { Nome = "cerveja Skol" });
           
            contextDB.GetColCervejas().ToList().ForEach(x => Console.WriteLine(x.Nome));
            Console.ReadKey();
        }
    }
}
