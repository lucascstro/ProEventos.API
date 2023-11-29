using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface
{
    public interface IPalestrantesPersistence
    {
         //PALESTRANTES
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includesPalestrantes = false);
        Task<Palestrante[]> GetAllPalestranteAsync(bool includesPalestrantes = false);
        Task<Palestrante[]> GetPalestranteByIdAsync(int palestranteId, bool includesPalestrantes = false);
    }
}