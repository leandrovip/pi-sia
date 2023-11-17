using Microsoft.EntityFrameworkCore;
using PI.SIA.Data;
using PI.SIA.Models;

namespace PI.SIA.Services;

public class ProfessorService
{
    #region Propriedades

    private readonly SiaContext _context;

    #endregion

    #region Construtores

    public ProfessorService(SiaContext context)
    {
        _context = context;
    }

    #endregion

    #region Métodos Públicos

    public async Task IncluirAsync(Professor professor)
    {
        _context.Professor.Add(professor);
        await _context.SaveChangesAsync();
    }

    public async Task EditarAsync(Professor professor)
    {
        _context.Professor.Update(professor);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Professor professor)
    {
        _context.Professor.Remove(professor);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Professor>> ObterTodosAsync()
    {
        return await _context.Professor.ToListAsync();
    }

    public async Task<Professor> ObterPorIdAsync(int id)
    {
        return await _context.Professor.FindAsync(id);
    }

    #endregion
}