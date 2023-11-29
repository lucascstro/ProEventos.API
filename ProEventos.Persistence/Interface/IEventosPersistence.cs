using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface
{
    public interface IEventosPersistence
    {
         //EVENTOS
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includesPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includesPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includesPalestrantes = false);
    }
}