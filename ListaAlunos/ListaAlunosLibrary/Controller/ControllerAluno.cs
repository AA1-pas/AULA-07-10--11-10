using ListaAlunosLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaAlunosLibrary.Controller
{
    public class ControllerAluno
    {
        public AlunosContextBD alunosDB = new AlunosContextBD();

        /// <summary>
        /// Metodo retorna tabela alunos
        /// </summary>
        /// <returns></returns>
        public IQueryable<Aluno> GetAlunos ()
        {
            return alunosDB.Alunos;
        }

        /// <summary>
        /// Metodo recebe objeto aluno e adiciona no BD
        /// Nome: String
        /// Idade: int
        /// Id: Key Autoincremento
        /// </summary>
        /// <param name="parametro">Parametro objeto Aluno para insserrir no BD</param>
        public void GetAddAlunos (Aluno parametro)
        {
            alunosDB.Alunos.Add(parametro);
            alunosDB.SaveChanges();
        }
    }
}
