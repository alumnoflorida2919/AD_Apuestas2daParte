using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class ApuestasController : ApiController
    {
        // GET: api/Apuestas
       // [Authorize(Roles = "Admin")]
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveDTO();
            //List<ApuestaDTO> apuestas = repo.RetrieveDTO();
            return apuestas;
        }
        // GET: api/Apuestas/5
        public Apuesta Get(int id)
        {
            var repo = new ApuestaRepository();
            Apuesta apuestas = repo.Retrieve(id);
            return apuestas;
            /*var repo = new ApuestaRepository();
            Apuesta a = repo.Retrieve();*/
            //return null;
        }
        //[Authorize]//solo los usuarios logueados pueden hacer apuestas
        // POST: api/Apuestas
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            repo.Save(apuesta);            
        }

        // PUT: api/Apuestas/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuestas/5
        public void Delete(int id)
        {
        }
    }
}
