
using CodeFirstTeste.Controller;
using CodeFirstTeste.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GambCodeFirst
{
    class Program
    {
        static ControllerCerveja cerveja = new ControllerCerveja();
        static void Main(string[] args)
        {
            cerveja.AddCerveja(new Cerveja() { Nome = "Allan", Teor = 2.5, Tipo = "Melhor" });
            cerveja.GetCervejas().ToList<Cerveja>().ForEach(x => Console.WriteLine(x.Nome));
            Console.ReadLine();
        }
    }
}
