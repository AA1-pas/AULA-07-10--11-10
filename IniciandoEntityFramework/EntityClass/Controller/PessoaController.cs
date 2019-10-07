using EntityClass.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClass.Controller
{
    
    public class PessoaController
    {
        //Realizo minha conexão com o banco de dados
        EntityContextDB contextDB = new EntityContextDB();

        //Aqui temos a primeira interface com a classe IQueryable, essa classe contem varias funcionalidades prontas
        //para usar igual ao banco de dados como os selects 
        public IQueryable<Pessoa> GetPessoa()
        {
            return contextDB.ListaDePessoas;
        }

        public void AddPessoa(Pessoa parametro)
        {
            contextDB.ListaDePessoas.Add(parametro);
            contextDB.SaveChanges();
        }

      
        
    }
}
