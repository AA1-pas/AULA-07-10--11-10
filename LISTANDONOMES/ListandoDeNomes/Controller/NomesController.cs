using ListandoDeNomes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListandoDeNomes.Controller
{
    public class NomesController
    {
        public NomeContextDB contextDb = new NomeContextDB();

        /// <summary>
        /// Metodo envia lista de todos os registros de nomes
        /// </summary>
        /// <returns>Retorna a lista de cadastros de nomes</returns>
        public IQueryable<NomePessoal> GetNomes ()
        {
            return contextDb.NomePessoas;
        }


        /// <summary>
        /// Metodo adiciona objeto(NomePessoal) no DB
        /// Nome: string 50
        /// Origem:string 50
        /// Id: key autoincremento
        /// </summary>
        /// <param name="parametro">Recebe objeto (NomePessoal) para adicionar no DB tabela NomePessoas</param>
        public void GetAddNomes(NomePessoal parametro)
        {
            contextDb.NomePessoas.Add(parametro);
            contextDb.SaveChanges();
        }

        public void GetDelNomes(int IdParametro)
        {
            
            var orderLine = contextDb.NomePessoas.SingleOrDefault(item => item.Id == IdParametro);

            if (orderLine != null)
            {
                contextDb.NomePessoas.Remove(orderLine);
                contextDb.SaveChanges();
            }
        }

    }

}

