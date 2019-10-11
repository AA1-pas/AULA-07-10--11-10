using EntityBicicletas.Controller;
using EntityBicicletas.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
            CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Menu();
        }

        public static void Menu()
        {
            int opcao = 0;
            while (opcao != 9)
            {
                Console.Clear();
                Console.Write("Digite uma opção:\n\n1 - Listar\n2 - Inserrir\n3 - Deletar\n4 - Atualizar\n9 - Sair\n\nOpção: ");
                int.TryParse(Console.ReadLine(), out opcao);
                switch (opcao)
                {
                    case 1:
                        GetLista();
                        Console.WriteLine("\nPressione 1 para exportar o relatório, ou qualque tecla para voltar.");
                        int.TryParse(Console.ReadLine(), out int opcaoexp);
                        if (opcaoexp == 1)
                        {
                            
                            Console.Write("Digite o caminho completo onde deseja salvar o arquivo: ");
                            ExportaArquivo(Console.ReadLine());
                            Console.WriteLine("Arquivo exportado com sucesso!");
                        }
                        Console.ReadKey();
                        break;
                    case 2:
                        AddBicicleta();
                        Console.ReadKey();
                        break;
                    case 3:
                        DelBicicleta();
                        Console.ReadKey();
                        break;
                    case 4:
                        AtuBicicleta();
                    
                        Console.ReadKey();
                        break;
                }
            }
        }

        public static void GetLista()
        {
            var lista = controller.GetBicicletas().OrderByDescending(x => x.Valor).Where(x => x.Ativo == true).ToList();
            lista.ForEach(x => Console.WriteLine
            ("Id: {0,-3} Modelo: {1,-20} Marca: {2,-15} Preço: {3,15} Ano: {4,4}", x.ID, x.Modelo.Nome, x.Marca.Nome, x.Valor.ToString("C2"), x.Ano));
            Console.WriteLine("\nSoma total: {0}", lista.Sum(x => x.Valor).ToString("C2",CultureInfo.CreateSpecificCulture("pt-BR"));
           
        }

        public static void GetMarcas()
        {
            var lista = controller.GetBicicletas().OrderByDescending(x => x.Valor).Where(x => x.Ativo == true).ToList();
            lista.ForEach(x => Console.WriteLine
            ("Id: {0,-3} Modelo: {1,-20} Marca: {2,-15} Preço: {3,15} Ano{4,4}", x.ID, x.Modelo.Nome, x.Marca.Nome, x.Valor.ToString("C2"), x.Ano));
            Console.WriteLine("\nSoma total: {0}", lista.Sum(x => x.Valor).ToString("C2"));

        }

        public static void AddBicicleta()
        {
            Bicicleta item = new Bicicleta();
            Marca marcaobj = null;
            Modelo modeloobj = null;
            while (marcaobj == null)
            {
                Console.Write("\nDigite o nome da Marca: ");
                var marca = Console.ReadLine();
                marcaobj = controller.GetMarcas().FirstOrDefault(x => x.Nome == marca);
            }
            item.MarcaID = marcaobj.Id;
            while (modeloobj == null)
            {
                Console.Write("\nDigite o modelo: ");
                var modelo = Console.ReadLine();
                modeloobj = controller.GetModelos().FirstOrDefault(x => x.Nome == modelo);
            }
            item.ModeloID = modeloobj.Id;
            Console.Write("\nDigite o Valor: ");
            double.TryParse(Console.ReadLine().Replace(",", "."), out double valor);
            item.Valor = valor;
            Console.Write("\nDigite o ano: ");
            int.TryParse(Console.ReadLine(), out int ano);
            item.Ano = ano;
            if (item.Valor <= 0 || item.Ano <= 0)
            {
                Console.WriteLine("Operacao não realizada");
                return;
            }
            if (controller.AddBicicleta(item))
                Console.WriteLine("Operação realizada");
            else
                Console.WriteLine("Operacao não realizada");
        }

        public static void DelBicicleta()
        {
            GetLista();
            Console.WriteLine("Digite o id que deseja remover");
            int.TryParse(Console.ReadLine(), out int id);
            if (controller.DelBicicleta(id))
                Console.WriteLine("Operação realizada");
            else
                Console.WriteLine("Operacao não realizada");
        }

        public static void AtuBicicleta()
        {
            GetLista();
            Console.WriteLine("\nLista de Marcas:");
            controller.GetMarcas().ToList().ForEach(x => Console.WriteLine("Id: {0,-3} Marca: {1,-15}", x.Id, x.Nome));
            Console.WriteLine("\nLista de Modelos:");
            controller.GetModelos().ToList().ForEach(x => Console.WriteLine("Id: {0,-3} Modelo: {1,-15}", x.Id, x.Nome));
            Console.WriteLine("\n\n");
            Console.WriteLine("Digite o id da bicicleta");
            int.TryParse(Console.ReadLine(), out int id);
            var item = controller.GetBicicletas().FirstOrDefault(x => x.Ativo == true && x.ID == id);
            if (item == null)
            {
                Console.WriteLine("Operação não realizada");
                return;
            }
            Console.Write("\nDigite o Id da Marca: ");
            int.TryParse(Console.ReadLine(), out int marcaid);
            Console.Write("\nDigite o Id modelo: ");
            int.TryParse(Console.ReadLine(), out int modeloid);
            Console.Write("\nDigite o Valor: ");
            double.TryParse(Console.ReadLine().Replace(",", "."), out double valor);

            Console.Write("\nDigite o ano: ");
            int.TryParse(Console.ReadLine(), out int ano);

            if (controller.GetMarcas().FirstOrDefault(x => x.Id == marcaid) != null)
                item.MarcaID = marcaid;
            if (controller.GetModelos().FirstOrDefault(x => x.Id == modeloid) != null)
                item.ModeloID = modeloid;
            if (valor > 0)
                item.Valor = valor;
            if (ano > 1900)
                item.Ano = ano;
            if (controller.AtuBicicleta(item))
                Console.WriteLine("Operação realizada");
            else
                Console.WriteLine("Operacao não realizada");
        }

        public static void ExportaArquivo(string caminhoExport)
        {


            var listaExp = controller.GetBicicletas().OrderByDescending(x => x.Valor).Where(x => x.Ativo == true).ToList();

            // 1: Escreve um linha para o novo arquivo
            using (StreamWriter writer = new StreamWriter(@caminhoExport + "Relatório.csv", false))
            {
                writer.WriteLine("Id;Modelo;Marca;Valor;Ano");
                foreach (var item in listaExp)
                {
                    var linha = item.ID + ";" + item.Modelo.Nome + ";" + item.Marca.Nome + ";" + item.Valor.ToString("C2") + ";" + item.Ano;
                    writer.WriteLine(linha);
                }
                string fim = "\nSoma total:"+";"+$"{listaExp.Sum(x => x.Valor).ToString("C2")}";
                writer.WriteLine(fim);
                
              
            }
        }
    }
}
