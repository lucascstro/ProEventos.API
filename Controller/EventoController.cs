using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class EventoController : ControllerBase
    {
        public readonly DataContext _Context;

        public EventoController(DataContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {

            return _Context.Eventos;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {

            return _Context.Eventos.Where(x=>x.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return $"Deu certo post";
        }


        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Deu certo put {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Deu certo delete {id}";
        }
    }
}