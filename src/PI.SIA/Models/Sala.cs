namespace PI.SIA.Models;

public class Sala
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int ProfessorId { get; set; }
    public List<Aluno> Alunos { get; set; }
    public virtual Professor Professor { get; set; }

    public Sala()
    {
        Alunos = new List<Aluno>();
    }
}