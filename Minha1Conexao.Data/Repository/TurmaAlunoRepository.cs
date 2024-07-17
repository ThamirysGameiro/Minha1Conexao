using Microsoft.EntityFrameworkCore;
using Minha1Conexao.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace Minha1Conexao.Data.Repository
{
    public class TurmaAlunoRepository : BaseRepository<TurmaAluno>
    {
        public List<TurmaAluno> SelecionarTudoCompleto()
        {
            return contexto.TurmaProfessor
                .Include(x => x.Aluno)
                .Include(x => x.Turma)
                .ToList();
        }

        public override void Incluir(TurmaAluno entity)
        {
            // colocar regras para inclusao


            base.Incluir(entity);
        }
    }
}
