using Microsoft.EntityFrameworkCore;
using PI.SIA.Data;
using PI.SIA.Models;

namespace PI.SIA.Services;

public class SalaService
{
    #region Propriedades

    private readonly SiaContext _context;

    #endregion

    #region Construtores

    public SalaService(SiaContext context)
    {
        _context = context;
    }

    #endregion

    #region Métodos Públicos

    public async Task IncluirAsync(Sala sala)
    {
        _context.Sala.Add(sala);
        await _context.SaveChangesAsync();
    }

    public async Task EditarAsync(Sala sala)
    {
        _context.Sala.Update(sala);
        await _context.SaveChangesAsync();
    }

    public async Task RemoverAsync(Sala sala)
    {
        _context.Sala.Remove(sala);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Sala>> ObterTodosAsync()
    {
        return await _context.Sala
            .Include(x => x.Professor)
            .Include(x => x.Alunos)
            .ToListAsync();
    }

    public async Task<Sala> ObterPorIdAsync(int id)
    {
        return await _context.Sala.FindAsync(id);
    }

    #endregion
}