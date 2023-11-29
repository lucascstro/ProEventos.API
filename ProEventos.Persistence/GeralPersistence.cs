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
    public class GeralPersistence : IGeralPersistence
    {

        public readonly ProEventosContext _Context;

        public GeralPersistence(ProEventosContext context)
        {
            _Context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _Context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _Context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _Context.Update(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _Context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _Context.SaveChangesAsync()) > 0;
        }
        
    }
}