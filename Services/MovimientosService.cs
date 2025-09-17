using GestionJugadores.DAL;
using Microsoft.EntityFrameworkCore;
using GestionJugadores.Models;
using System.Linq.Expressions;

namespace GestionJugadores.Services;

public class MovimientosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(Movimientos movimiento)
    {
        if (!await Existe(movimiento.MovimientoId))
        {
            return await Insertar(movimiento);
        }

        else
        {
            return await Modificar(movimiento);
        }
    }

    private async Task<bool> Existe (int movimientoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos.AnyAsync(m => m.MovimientoId == movimientoId);
    }

    private async Task<bool> Insertar (Movimientos movimiento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Movimientos.Add(movimiento);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task <bool> Modificar (Movimientos movimiento)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.Movimientos.Update(movimiento);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task <Movimientos?> Buscar (int movimientoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos.FirstOrDefaultAsync(m => m.MovimientoId == movimientoId);
    }

    public async Task<bool> Eliminar (int movimientoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos
            .AsNoTracking()
            .Where(m => m.MovimientoId == movimientoId)
            .ExecuteDeleteAsync() > 0;
    }

    public async Task<List<Movimientos>> Listar (Expression<Func<Movimientos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Movimientos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}
