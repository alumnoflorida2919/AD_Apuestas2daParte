using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public IEnumerable<Evento> Get()
        {
            var repo = new EventoRepository();
            List<Evento> eventos = repo.Retrieve();
            //List<Evento> eventos = repo.Retrieve();
            return eventos;
        }
        
        // GET: api/Eventos/5
        /*public Evento Get(int id)
        {
            var repo = new EventoRepository();
            List<Evento> eventos = repo.Retrieve();
            /*Evento e = repo.Retrieve();
            return eventos;
        }*/

        // POST: api/Eventos
        public void Post([FromBody]Evento evento)
        {
            var repo = new EventoRepository();
            repo.Save(evento);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
