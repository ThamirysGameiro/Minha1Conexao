using Microsoft.AspNetCore.Mvc;
using Minha1Conexao.Data.Repository;
using Minha1Conexao.Domain;

namespace Minha1Conexao.API.Controllers
{
    public class ProfessorController : ControllerBase
    {
        private readonly ProfessorRepository repo;

        public ProfessorController()
        {
            repo = new ProfessorRepository();
        }

        //[HttpGet]
        //public IEnumerable<Professor> Get()
        //{
        //    return repo.SelecionarTudo();
        //}

        //[HttpGet("{id}")]
        //public Professor Get(int id)
        //{
        //    return repo.Selecionar(id);
        //}

        [HttpPost]
        public IEnumerable<Professor> Post([FromBody] Professor prof)
        {
            repo.Incluir(prof);

            return repo.SelecionarTudo();
        }
        [HttpPut]
        public IEnumerable<Professor> Put([FromBody] Professor prof)
        {
            repo.Alterar(prof);
            return repo.SelecionarTudo();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Professor> Delete(int id)
        {
            repo.Excluir(id);
            return repo.SelecionarTudo();
        }
    }
}
