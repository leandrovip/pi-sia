using Microsoft.EntityFrameworkCore;
using PI.SIA.Data;
using PI.SIA.Models;

namespace PI.SIA.Services;

public class NotaService
{
    #region Propriedades

    private readonly SiaContext _context;

    #endregion

    #region Construtores

    public NotaService(SiaContext context)
    {
        _context = context;
    }

    #endregion

    #region Métodos Públicos

    public async Task IncluirAsync(Nota nota)
    {
        _context.Nota.Add(nota);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Nota>> ObterTodosAsync()
    {
        return await _context.Nota
            .Include(x => x.Sala)
            .Include(x => x.Aluno)
            .ToListAsync();
    }

    public async Task<List<RelatorioNotaDto>> ObterRelatorioNotasAsync()
    {
        var alunosComNotas = await _context.Aluno
            .Select(aluno => new RelatorioNotaDto
            {
                Nome = aluno.Nome,
                Quantidade = aluno.Notas.Count,
                Media = aluno.Notas.Any() ? aluno.Notas.Average(nota => nota.Valor) : 0,
                Aprovado = aluno.Notas.Any() && aluno.Notas.Average(nota => nota.Valor) >= 6
            })
            .ToListAsync();

        return alunosComNotas;
    }

    #endregion
}