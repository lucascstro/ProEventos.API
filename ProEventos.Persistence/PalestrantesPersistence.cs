using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;

namespace ProEventos.Persistence
{
    public class PalestrantePersistence : IPalestrantePersistence
    {

        public readonly ProEventosContext _Context;

        public PalestrantePersistence(ProEventosContext context)
        {
            _Context = context;
        }

        public async Task<Palestrante[]> GetAllPalestranteAsync(bool includesEventos = false)
        {
            IQueryable<Palestrante> query = _Context.Palestrantes
                                        .Include(e => e.RedesSociais);
            if (includesEventos)
            {
                query.AsNoTracking().Include(e => e.PalestranteEventos)
                      .ThenInclude(pe => pe.Evento);
            }
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includesEventos = false)
        {
            IQueryable<Palestrante> query = _Context.Palestrantes
                                       .Include(e => e.RedesSociais);
            if (includesEventos)
            {
                query.Include(e => e.PalestranteEventos)
                      .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Nome)
                    .Where(e => e.Nome.ToLower() == nome.ToLower());

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante[]> GetPalestranteByIdAsync(int palestranteId, bool includesPalestrantes = false)
        {
            IQueryable<Palestrante> query = _Context.Palestrantes
                            .Include(e => e.RedesSociais);
            if (includesPalestrantes)
            {
                query.Include(e => e.PalestranteEventos)
                      .ThenInclude(pe => pe.Evento);
            }

            query = query.AsNoTracking().OrderBy(e => e.Nome)
                    .Where(e => e.Id == palestranteId);

            return await query.ToArrayAsync();
        }

    }

    public interface IPalestrantePersistence
    {
    }
}