using PlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet.Controllers
{
    public class MercadosController : ApiController
    {
        // GET: api/Mercados
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadoRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();
            //List<Mercado> mercados = repo.Retrieve();
            return mercados;
        }
        /// <summary>
        /// filtra de mercado a traves de tipo y evento
        /// </summary>        
        // GET: api/Mercados?Eventos_indentificacdor_eventos=Eventos_indentificacdor_eventos&OverUnder=OverUnder
        public IEnumerable<Mercado> GetMarket(double tipo,int evento)
        {
            var repo = new MercadoRepository();
            List<Mercado> mercados = repo.GiveMeMarket(tipo,evento);
            //List<Mercado> mercados = repo.Retrieve();
            return mercados;
        }
        // GET: api/Mercados/5
        public Mercado Get(int id)
        {
            /*var repo = new MercadoRepository();
            Mercado m= repo.Retrieve();*/
            return null;
        }

        // POST: api/Mercados
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercados/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercados/5
        public void Delete(int id)
        {
        }
    }
}
