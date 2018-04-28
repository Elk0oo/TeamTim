using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class EtapeController : ApiController
    {
        Repository r;
        public EtapeController()
        {
            r = new Repository();
        }
        [HttpGet]
        [Route("api/getEtapes/{idJeu}")]
        public IHttpActionResult getEtapes(int idJeu)
        {
            return Ok(r.getEtapes(idJeu));
        }

        // GET: api/Etape/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Etape
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Etape/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Etape/5
        public void Delete(int id)
        {
        }
    }
}
