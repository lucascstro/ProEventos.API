using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IEventosPersistence _eventosPersistence;
        private readonly IGeralPersistence _geralPersistence;
        public EventoService(IGeralPersistence geralPersistence, IEventosPersistence eventosPersistence)
        {
            this._eventosPersistence = eventosPersistence;
            this._geralPersistence = geralPersistence;
        }
        public async Task<Evento> AddEvento(Evento model)
        {
            try
            {
                _geralPersistence.Add<Evento>(model);
                if (await _geralPersistence.SaveChangesAsync())
                    return await _eventosPersistence.GetEventoByIdAsync(model.Id, false);

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int EventoId, Evento model)
        {
            try
            {
                if (_eventosPersistence.GetEventoByIdAsync(EventoId, false) == null)
                    return null;

                _geralPersistence.Update(model);
                if (await _geralPersistence.SaveChangesAsync())
                    return await _eventosPersistence.GetEventoByIdAsync(model.Id, false);
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, false);
                if (evento == null) throw new Exception("Nenhum evento encontrado para o id.");

                _geralPersistence.Delete<Evento>(evento);
                return await _geralPersistence.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento[]> GetAllEventosAsync(bool includesPalestrantes = false)
        {
            try
            {
                return await _eventosPersistence.GetAllEventosAsync(includesPalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includesPalestrantes = false)
        {
            try
            {
                return await _eventosPersistence.GetAllEventosByTemaAsync(tema, includesPalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includesPalestrantes = false)
        {
            try
            {
                return await _eventosPersistence.GetEventoByIdAsync(eventoId, includesPalestrantes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
//teste