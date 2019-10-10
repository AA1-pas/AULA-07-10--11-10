using Entity.Controller;
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio2
{
    class Program
    {
        static ControllerFlores controller = new ControllerFlores();
        static void Main(string[] args)
        {
            int opcao = 0;
            while(opcao !=3)
            {
                Console.Clear();
                Console.Write("Digite a opção:\n\n1 - Cadastrar Flor\n2 - Listar Flores\n3 - Sair\n\nOpção: ");
                int.TryParse(Console.ReadLine(), out opcao);
                switch(opcao)
                {
                    case 1:
                        AddFlor();
                        break;
                    case 2:
                        ListaFlores();
                        break;
                }
            }
        }
        public static void AddFlor()
        {
            Flor item = new Flor();
            Console.WriteLine("Digite o nome da flor que deseja cadastrar:");
            item.Nome = Console.ReadLine();
            Console.WriteLine("Digite a quantidade de flor:");
            int.TryParse(Console.ReadLine(), out int quant);
            item.Quantidade = quant;
            if (string.IsNullOrWhiteSpace(item.Nome) || quant <= 0)
            {
                Console.WriteLine("Operação não realizada");
                return;
            }
            if (controller.AddFlor(item))
                Console.WriteLine("Operação realizada");
            else
                Console.WriteLine("Operação não realizada");
            Console.ReadKey();
        }

        public static void ListaFlores()
        {
            var lista = controller.GetFlores().OrderByDescending(x => x.Quantidade).ToList<Flor>();
            lista.ForEach(x => Console.WriteLine("Id: {0,-3} Nome: {1,-30} Quantidade: {2,-8}", x.Id,x.Nome,x.Quantidade));
            Console.WriteLine($"\nTotal de {lista.Sum(x=> x.Quantidade)} flores");
            Console.ReadKey();
        }
    }
}
