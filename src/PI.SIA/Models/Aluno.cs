namespace PI.SIA.Models;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string RegistroAluno { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Endereco { get; set; }

    public virtual List<Nota> Notas { get; set; }
}