using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Domain;
using ProEventos.Persistence;
using ProEventos.Persistence.Context;

namespace ProEventos.API.Controllers
{

    [ApiController]
    [Route("Api/[controller]")]
    public class EventoController : ControllerBase
    {
          public readonly ProEventosContext _Context;
        public EventoController(ProEventosContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return [];
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return [];
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