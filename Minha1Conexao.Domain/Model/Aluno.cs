using Minha1Conexao.Domain.Model;
using System.Collections.Generic;

namespace Minha1Conexao.Domain
{
    public class Aluno : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public List<TurmaAluno> TurmaAluno { get; private set; }

        public static Aluno NovoAluno(string nome)
        {
            var aluno = new Aluno();
            aluno.Nome = nome;
            aluno.Ativo = true;
            return aluno;
        }

        public Aluno AlterarNome(string novoNome) 
        {
            Nome = novoNome;
            return this;
        }
    }
}
