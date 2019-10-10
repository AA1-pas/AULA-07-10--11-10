using DBNomes.Controller;
using DBNomes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    class Program
    {
        static ControllerNomes controller = new ControllerNomes();
        static void Main(string[] args)
        {
            int opcao = 0;
            while(opcao!=3)
            {
                Console.Clear();
                Console.Write("1 - Adicionar Nomes\n2 - Listar Nomes\n3 - Sair\n\nDigite a opção:");
                int.TryParse(Console.ReadLine(), out opcao);
                switch(opcao)
                {
                    case 1:
                        AddNome();
                        break;
                    case 2:
                        ListaNomes();
                        break;
                }
            }

        }

        static void AddNome()
        {
            Console.Write("Digite o nome que deseja adicionar: ");
            Nome item = new Nome();
            item.NomeComp = Console.ReadLine();
            if (item.NomeComp == null)
            {
                Console.WriteLine("Operação não concluida");
                return;
            }
            if(controller.AddNomes(item))
                Console.WriteLine("Operação concluida");
            else
                Console.WriteLine("Operação não concluida");
            Console.ReadKey();
        }

        static void ListaNomes()
        {
            controller.GetNomes().ToList<Nome>().ForEach(x => Console.WriteLine("Nome: {0,-30}", x.NomeComp));
            Console.ReadKey();
        }
    }
}
