using ListandoDeNomes.Controller;
using ListandoDeNomes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNomes
{
    class Program
    {
        static NomesController nomes = new NomesController();
    
            static void Main(string[] args)
            {
                MenuPrincipal();

            }

            /// <summary>
            /// Metodo que apresenta Menu principal
            /// </summary>
            public static void MenuPrincipal()
            {
                int opcao = 0;
                while (opcao != 9)
                {
                    Console.Clear();
                    Console.WriteLine("*** *** Sistema Cadastro Nomes *** ***\n");
                    Console.Write("1 - Lista de Nomes\n2 - Cadastrar Nomes\n9 - Sair\n\nOpção: ");
                    int.TryParse(Console.ReadLine(), out opcao);
                    switch (opcao)
                    {
                        case 1:
                            ListaNomes();
                            break;
                        case 2:
                            AddNomes();
                            break;
                    }
                }
            }

            /// <summary>
            /// Metodo que traz todos os cadastros de Nomes
            /// Id, Nome, Idade
            /// </summary>
            public static void ListaNomes()
            {
                nomes.GetNomes().ToList<NomePessoal>().ForEach(x => Console.WriteLine("Id: {0,-2} Nome: {1,-10} Origem: {2,3}", x.Id, x.Nome, x.Origem));
                Console.ReadKey();
            }

            /// <summary>
            /// Metodo que envia objeto (NomePessoal) para cadastro no BD
            /// Nome: String
            /// Origem: String
            /// ID: Key autoincremento
            /// </summary>
            public static void AddNomes()
            {
                Console.WriteLine("Digite o nome:");
                string nome = Console.ReadLine();
                Console.WriteLine("Digite a origem");
                string origem = Console.ReadLine();
                nomes.GetAddNomes(new NomePessoal()
                {
                    Nome = nome,
                    Origem = origem
                });
            }
        }
    }

