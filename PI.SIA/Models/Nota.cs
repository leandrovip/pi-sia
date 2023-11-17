namespace PI.SIA.Models;

public class Nota
{
    public int Id { get; set; }
    public int AlunoId { get; set; }
    public int SalaId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataNota { get; set; }

    public virtual Aluno Aluno { get; set; }
    public virtual Sala Sala { get; set; }
}