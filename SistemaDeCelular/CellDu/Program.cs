using CatalogoCelulares.Controller;
using CatalogoCelulares.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellDu
{
    class Program
    {
        static CelularesController controller = new CelularesController();
        static void Main(string[] args)
        {
            Menu();
        
            Console.WriteLine("\n\n*** SAINDO DO SISTEMA ***");
        }

        public static void Menu()
        {
            int opcao = 0;
            while(opcao !=9 )
            {
                Console.Clear();
                Console.WriteLine("********** Sistema Cadastro de Celulares **********\n\n");
                Console.WriteLine("Selecione uma opção:\n");
                Console.Write("1-Lista de Celulares\n2-Cadastro Celulares\n3-Remover Celular\n4-Atualizar Celular\n9-Sair\n\nOpção: ");
                int.TryParse(Console.ReadLine(), out opcao);
                switch(opcao)
                {
                    case 1:
                        ListaCelulares();
                        RetornaMenu();
                        break;
                    case 2:
                        AddCelular();
                        RetornaMenu();
                        break;
                    case 3:
                        RemCelular();
                        RetornaMenu();
                        break;
                    case 4:
                        AtualizaCelular();
                        RetornaMenu();
                        break;
                }

            }
            
        }

        /// <summary>
        /// Metodo adiciona celular
        /// </summary>
        public static void AddCelular()
        {
            Console.Write("Digite a Marca do celular: ");
            var marca = Console.ReadLine();
            Console.Write("Digite o Modelo do celular: ");
            var modelo = Console.ReadLine();
            Console.Write("Digite o valor do celular: ");
            double.TryParse(Console.ReadLine(), out double preco);
            if (controller.AddCelular(new Celular()
            {
                Marca = marca,
                Modelo = modelo,
                Preco = preco
            }))
                Console.WriteLine("\nOperação realizada com Sucesso!!!");
            else
                Console.WriteLine("\nOperação não realizada!!!");
        }

        /// <summary>
        /// Metodo desativa (seta campo Ativo como 0) celular
        /// </summary>
        public static void RemCelular()
        {
            ListaCelulares();
            Console.Write("\nDigite o id do celular que deseja remover:");
            int.TryParse(Console.ReadLine(), out int id);
            if(controller.RemCelular(id))
                Console.WriteLine("\nOperação realizada com Sucesso!!!");
            else
                Console.WriteLine("\nOperação não realizada!!!");
        }

        /// <summary>
        /// Metodo lista celulares ativos
        /// </summary>
        public static void ListaCelulares()
        {
            Console.WriteLine("\nLista de celulares:");
            controller.GetCelulares().ToList().ForEach(x => Console.WriteLine
            ("Id: {0,-4} Modelo: {1,-20} Marca: {2,-20} Preço: {3,-20}",x.Id,x.Modelo,x.Marca,x.Preco.ToString("C2")));
        }

        /// <summary>
        /// Metodo aguarda usuario pressionar uma tecla, apos pressionada a tecla limpa a tela 
        /// </summary>
        public static void RetornaMenu()
        {
            Console.WriteLine("\nPressione qualquer tecla para retornar.");
            Console.ReadKey(true);
            Console.Clear();
        }

        /// <summary>
        /// Metodo Atualiza o objeto celular
        /// </summary>
        public static void AtualizaCelular ()
        {
            ListaCelulares();
            Console.Write("\nDigite o número de Id do celular que deseja atualizar: ");
            int.TryParse(Console.ReadLine(),out int id);
            var item = controller.GetCelulares().FirstOrDefault(x => x.Id == id);
            if (item == null)
            {
                Console.WriteLine("\n*** ID INEXISTENTE ***");
                return;
            }
            Console.Write("Digite o modelo para atualizar ou deixe em branco para manter o atual:");
            var modelo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(modelo)==false)
                item.Modelo = modelo;
            Console.Write("Digite a marca para atualizar ou deixe em branco para manter a atual:");
            var marca = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(marca) == false)
                item.Marca = marca;
            Console.Write("Digite o valor para atualizar ou deixe em branco para manter o atual:");
            double.TryParse(Console.ReadLine(), out double preco);
            if (preco >0)
                item.Preco = preco;
            if (controller.AtuCelular(item))
            Console.WriteLine("\nOperação realizada com Sucesso!!!");
            else
                Console.WriteLine("\nOperação não realizada!!!");
        }


     
    }
}
