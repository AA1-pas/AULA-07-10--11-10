using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListaAlunosLibrary.Controller;
using ListaAlunosLibrary.Model;

namespace ListaAlunosInterface
{
    class Program
    {
        static ControllerAluno controllerAluno = new ControllerAluno();
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
                Console.WriteLine("*** *** Sistema Cadastro Alunos *** ***\n");
                Console.Write("1 - Lista de Alunos\n2 - Cadastrar Aluno\n9 - Sair\n\nOpção: ");
                int.TryParse(Console.ReadLine(), out opcao);
                switch (opcao)
                {
                    case 1:
                        ListaAlunos();
                        break;
                    case 2:
                        AddAlunos();
                        break;
                }
            }
        }

        /// <summary>
        /// Metodo que traz todos os cadastros de Alunos
        /// Id, Nome, Idade
        /// </summary>
        public static void ListaAlunos()
        {
            controllerAluno.GetAlunos().ToList<Aluno>().ForEach(x => Console.WriteLine("Id: {0,-2} Nome: {1,-10} Idade: {2,3}",x.id, x.Nome, x.Idade));
            Console.ReadKey();
        }

        /// <summary>
        /// Metodo que envia objeto (Aluno) para cadastro no BD
        /// Nome: String
        /// Idade: Int
        /// ID: Key autoincremento
        /// </summary>
        public static void AddAlunos()
        {
            Console.WriteLine("Digite o nome do aluno:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a idade do aluno:");
            int idade = int.Parse(Console.ReadLine());
            controllerAluno.GetAddAlunos(new Aluno()
            {
                Nome = nome,
                Idade = idade
            });
        }
    }
}
