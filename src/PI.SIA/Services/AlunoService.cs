using Microsoft.EntityFrameworkCore;
using PI.SIA.Data;
using PI.SIA.Models;

namespace PI.SIA.Services;

public class AlunoService
{
    #region Propriedades

    private readonly SiaContext _context;

    #endregion

    #region Construtores

    public AlunoService(SiaContext context)
    {
        _context = context;
    }

    #endregion

    #region Métodos Públicos

    public async Task IncluirAsync(Aluno aluno)
    {
        _context.Aluno.Add(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task EditarAsync(Aluno aluno)
    {
        _context.Aluno.Update(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Aluno aluno)
    {
        _context.Aluno.Remove(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Aluno>> ObterTodosAsync()
    {
        return await _context.Aluno.ToListAsync();
    }

    public async Task<Aluno> ObterPorIdAsync(int id)
    {
        return await _context.Aluno.FindAsync(id);
    }

    #endregion
}