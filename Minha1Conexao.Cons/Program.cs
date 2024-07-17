

using Minha1Conexao.Data.Repository;
using Minha1Conexao.Domain;
using Minha1Conexao.Domain.Model;

class Program
{  

    static void Main(string[] args)
    {
        var alunos = CrudAlunos();
        var professor = CRProfessor();
        var turma = CRTurma(professor.FirstOrDefault().Id);
        CRTurmaAluno(alunos, turma.FirstOrDefault().Id);
    }

    private static List<Aluno> CrudAlunos()
    {
        IncluirAluno("Diana");
        IncluirAluno("Billy");

        var alunos = ConsultarAlunos();

        AlterarAluno(alunos[0].AlterarNome("Diana Golden"));
        ExcluirAluno(alunos[1].Id);
        return ConsultarAlunos();
    }

    private static void IncluirAluno(string nome)
    {
        var repoAluno = new AlunoRepository();
        repoAluno.Incluir(Aluno.NovoAluno(nome));
    }

    private static void AlterarAluno(Aluno aluno) 
    {
        var repoAluno = new AlunoRepository();
        repoAluno.Alterar(aluno);
    }

    private static List<Aluno> ConsultarAlunos()
    {
        var repoAluno = new AlunoRepository();        
        var alunos = repoAluno.SelecionarTudo();

        Console.WriteLine("Lista de alunos ->");
        foreach (var aluno in alunos)
        {
            Console.WriteLine(aluno.Nome);
        }
        Console.WriteLine();

        return alunos;
    }

    private static void ExcluirAluno(int id)
    {
        var repoAluno = new AlunoRepository();
        repoAluno.Excluir(id);
    }

    private static List<Professor> CRProfessor()
    {
        IncluirProfessor("Thamy", "t@t.com", Turno.Manha);
        return ConsultarProfessor();
    }

    private static void IncluirProfessor(string nome, string email, Turno turno)
    {
        var repoProf = new ProfessorRepository();
        repoProf.Incluir(Professor.NovoProfessor(nome, email, turno));
    }

    private static List<Professor> ConsultarProfessor()
    {
        var repoProf = new ProfessorRepository();
        var professor = repoProf.SelecionarTudo();

        Console.WriteLine("Lista de professores ->");
        foreach (var prof in professor)
        {
            Console.WriteLine(prof.Nome);
        }
        Console.WriteLine();

        return professor;
    }

    private static List<Turma> CRTurma(int idProfessor)
    {
        IncluirTurma("C# Intermediário", idProfessor);
        return ConsultarTurma();
    }

    private static void IncluirTurma(string nome, int idProfessor)
    {
        var repoTurma = new TurmaRepository();
        repoTurma.Incluir(Turma.NovaTurma(nome, idProfessor));
    }

    private static List<Turma> ConsultarTurma()
    {
        var repoTurma = new TurmaRepository();
        var turmas = repoTurma.SelecionarTudo();

        Console.WriteLine("Lista de Turmas ->");
        foreach (var turma in turmas)
        {
            Console.WriteLine(turma.Nome);
        }
        Console.WriteLine();

        return turmas;
    }

    private static List<TurmaAluno> CRTurmaAluno(List<Aluno> alunos, int idCurso)
    {
        IncluirTurmaAluno(alunos, idCurso);
        return ConsultarTurmaAluno();
    }

    private static void IncluirTurmaAluno(List<Aluno> alunos, int idCurso)
    {
        var repoTurmaAluno = new TurmaAlunoRepository();

        foreach (var aluno in alunos) 
        {
            repoTurmaAluno.Incluir(TurmaAluno.MatricularAluno(aluno.Id, idCurso));
        }        
    }

    private static List<TurmaAluno> ConsultarTurmaAluno()
    {
        var repoTurmaAluno = new TurmaAlunoRepository();
        var turmaAluno = repoTurmaAluno.SelecionarTudoCompleto();

        Console.WriteLine("Matriculas ->");
        foreach (var ta in turmaAluno)
        {
            Console.WriteLine($"O aluno {ta.Aluno.Nome} foi matriculado no curso {ta.Turma.Nome}");
        }
        Console.WriteLine();

        return turmaAluno;
    }


}