using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence
{
    public class EventosPersistence : IEventosPersistence
    {

        public readonly ProEventosContext _Context;

        public EventosPersistence(ProEventosContext context)
        {
            _Context = context;
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includesPalestrantes = false)
        {
            IQueryable<Evento> query = _Context.Eventos
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);
            if (includesPalestrantes)
            {
                query.Include(e => e.PalestranteEventos)
                      .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id);
            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includesPalestrantes = false)
        {
            IQueryable<Evento> query = _Context.Eventos
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);
            if (includesPalestrantes)
            {
                query.Include(e => e.PalestranteEventos)
                      .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id).Where(e => e.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includesPalestrantes = false)
        {
            IQueryable<Evento> query = _Context.Eventos
                                        .Include(e => e.Lotes)
                                        .Include(e => e.RedesSociais);
            if (includesPalestrantes)
            {
                query.Include(e => e.PalestranteEventos)
                      .ThenInclude(pe => pe.Palestrante);
            }

            query = query.AsNoTracking().OrderBy(e => e.Id)
                    .Where(e => e.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

    }
}