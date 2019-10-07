using EntityClass.Controller;
using EntityClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessandoEntity
{
    class Program
    {
        static PessoaController pessoa = new PessoaController();
        static void Main(string[] args)
        {
            
            pessoa.AddPessoa(new Pessoa() 
            {
                Nome = "Allan"
            });
           
                pessoa.GetPessoa().ToList<Pessoa>().ForEach(x => Console.WriteLine(x.Nome));
    
            Console.ReadKey();
        }
    }
}
 