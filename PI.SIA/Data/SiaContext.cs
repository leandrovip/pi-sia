using Microsoft.EntityFrameworkCore;
using PI.SIA.Models;

namespace PI.SIA.Data;

public class SiaContext : DbContext
{
    #region Propriedades

    public DbSet<Aluno> Aluno { get; set; }
    public DbSet<Professor> Professor { get; set; }
    public DbSet<Sala> Sala { get; set; }
    public DbSet<Nota> Nota { get; set; }

    #endregion

    #region Construtores

    public SiaContext(DbContextOptions<SiaContext> options) : base(options)
    {

    }

    #endregion
}