using Minha1Conexao.Domain.Model;
using System.Collections.Generic;

namespace Minha1Conexao.Domain
{
    public class Professor : IEntity
    {
        public int Id { get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Turno Turno { get; private set; }
        public string Banco { get; private set; }
        public string Agencia { get; private set; }
        public string Conta { get; private set; }
        //public List<TurmaProfessor> TurmaProfessor { get; set; }
        public List<Turma> Turmas { get; set; }
        
        public static Professor NovoProfessor(string nome, string email, Turno turno)
        {
            var prof = new Professor();
            prof.Nome = nome;
            prof.Email = email; 
            prof.Turno = turno;

            return prof;
        }
    
    }

    

    public enum Turno
    {
        Manha,
        Tarde,
        Noite,
        Integral
    }
}
