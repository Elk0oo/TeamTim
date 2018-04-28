using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class EquipeController : ApiController
    {
        Repository r;
            public EquipeController()
        {
            r = new Repository();
        }
        // GET: api/Equipe
        [HttpGet]
        [Route("api/AddIdEquipe/{idJeu}")]
        public int AddIdEquipe(int idJeu)
        {
            return r.AddIdEquipe(idJeu);
        }

        [HttpGet]
        [Route("api/GetIdEquipe/{idJeu}")]
        public int GetIdEquipe(int idJeu)
        {
            return r.GetIdEquipe(idJeu);
        }

        // GET: api/Equipe/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Equipe
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Equipe/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Equipe/5
        public void Delete(int id)
        {
        }
    }
}
