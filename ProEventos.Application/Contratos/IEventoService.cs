using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
        Task<Evento> AddEvento(Evento model);
        Task<Evento> UpdateEvento(int EventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includesPalestrantes = false);
        Task<Evento[]> GetAllEventosAsync(bool includesPalestrantes = false);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includesPalestrantes = false);
    }
}