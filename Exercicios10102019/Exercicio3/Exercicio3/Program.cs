using EntityBicicletas.Controller;
using EntityBicicletas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3
{
    class Program
    {
        static ControllerBicicletas controller = new ControllerBicicletas();
        static void Main(string[] args)
        {
        }

        public static void Menu()
        {
            int opcao = 0;
            while(opcao!=9)
            {
                Console.Clear();
                Console.Write("Digite uma opção:\n\n1 - Listar\n2 - Inserrir\n3 - Deletar\n4 - Atualizar\n9 - Sair\n\nOpção: ");
                int.TryParse(Console.ReadLine(), out opcao);
                switch(opcao)
                {
                    case 1:
                        GetLista();
                        break;
                    case 2:
                        AddBicicleta();
                        break;
                    case 3:
                        DelBicicleta();
                        break;
                    case 4:
                        break;
                }
            }
        }

        public static void GetLista()
        {
           var lista = controller.GetBicicletas().OrderBy(x => x.Modelo).Where(x => x.Ativo == true).ToList();
           lista.ForEach(x => Console.WriteLine
           ("Id: {0,-3} Modelo: {1,-20} Marca: {2,-15} Preço: {3,8} Ano{4,4}", x.ID,x.Modelo,x.Marca,x.Valor.ToString("C2"),x.Ano));
        }

        public static void AddBicicleta()
        {
            Bicicleta item = new Bicicleta();
            Console.Write("\nDigite o nome da Marca");
            item.Marca = Console.ReadLine();
            Console.Write("\nDigite o modelo");
            item.Modelo = Console.ReadLine();
            Console.Write("\nDigite o Valor");
            int.TryParse(Console.ReadLine(), out int valor);
            item.Valor = valor;
            Console.Write("\nDigite o ano");
            int.TryParse(Console.ReadLine(), out int ano);
            item.Ano = ano;
            if (string.IsNullOrWhiteSpace(item.Marca) || string.IsNullOrWhiteSpace(item.Modelo) || item.Valor<=0 || item.Ano<=0)
            {
                Console.WriteLine("Operacao não realizada");
                return;
            }
            if(controller.AddBicicleta(item))
                Console.WriteLine( "Operação realizada" );
            else
                Console.WriteLine("Operacao não realizada");
        }

        public static void DelBicicleta()
        {
            GetLista();
            Console.WriteLine("Digite o id que deseja remover");
            int.TryParse(Console.ReadLine(), out int id);
            if(controller.DelBicicleta(id))
                Console.WriteLine("Operação realizada");
            else
                Console.WriteLine("Operacao não realizada");
        }

        public static void AtuBicicleta()
        {
            Console.WriteLine("Digite o id da bicicleta");
            int.TryParse(Console.ReadLine(), out int id);
            var item = controller.GetBicicletas().FirstOrDefault(x => x.Ativo == true && x.ID == id);
            if (item==null)
            {
                Console.WriteLine("Operação não realizada");
                return;
            }
            Console.Write("\nDigite o nome da Marca");
            var marca = Console.ReadLine();
            Console.Write("\nDigite o modelo");
            var modelo = Console.ReadLine();
            Console.Write("\nDigite o Valor");
            int.TryParse(Console.ReadLine(), out int valor);

            Console.Write("\nDigite o ano");
            int.TryParse(Console.ReadLine(), out int ano);

            if (!string.IsNullOrWhiteSpace(marca))
                item.Marca = marca;
            if (!string.IsNullOrWhiteSpace(modelo))
                item.Modelo = modelo;
            if (valor > 0)
                item.Valor = valor;
            if (ano > 1900)
                item.Ano = ano;
            if (controller.AtuBicicleta(item))
                Console.WriteLine("Operação realizada");
            else
                Console.WriteLine("Operacao não realizada");
        }
    }
}
