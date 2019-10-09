using CatalogoCelulares.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoCelulares.Controller
{
    public class CelularesController
    {
        CelularesContextDB celularesDB = new CelularesContextDB();

        /// <summary>
        /// Metodo traz a lista de celulares ativos
        /// </summary>
        /// <returns>Retorna lista de celulares ativos</returns>
        public IQueryable<Celular> GetCelulares ()
        {
            return celularesDB.Celulares.Where(x => x.Ativo == true);
        }

        /// <summary>
        /// Metodo adiciona celulares
        /// </summary>
        /// <param name="item">Recebe objeto Celular para adicionar no DB</param>
        /// <returns>Retorna true para inserção do registro realizada, ou false para não realizada</returns>
        public bool AddCelular(Celular item)
        {
            if (string.IsNullOrWhiteSpace(item.Marca))
                return false;
            if (string.IsNullOrWhiteSpace(item.Modelo))
                return true;
            if (item.Preco <= 0)
                return false;
            celularesDB.Celulares.Add(item);
            celularesDB.SaveChanges();
            return true;
        }

        /// <summary>
        /// Metodo seta Ativo=0  do celular
        /// </summary>
        /// <param name="id">Recebe o numero do Id do Celular para realizar a operação</param>
        /// <returns>Retorna true para atualização do campo Ativo realizada, ou false para não realizada</returns>
        public bool RemCelular(int id)
        {
             var celular = celularesDB.Celulares.FirstOrDefault(x => (x.Id == id) && (x.Ativo == true));
    
            if (celular == null)
                return false;
            else
                celular.Ativo = false;
            celularesDB.SaveChanges();
            return true;
        }

        /// <summary>
        /// Metodo atualiza campos do cadastro do celular
        /// </summary>
        /// <param name="item">Recebe objeto Celular para atualizar no DB</param>
        /// <returns>Retorna true para atualização dos campos celular realizada, ou false para não realizada</returns>
        public bool AtuCelular(Celular item)
        {
            if (celularesDB.Celulares.FirstOrDefault(x => x.Id == item.Id && x.Ativo == true) == null)
                return false;
            item.DataAlteracao = DateTime.Now;
            celularesDB.SaveChanges();
            return true;
        }
    }
}
