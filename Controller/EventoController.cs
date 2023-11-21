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
        public EventoController()
        {

        }

        [HttpGet]
        public string Get()
        {
            return "Deu certo get";  
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