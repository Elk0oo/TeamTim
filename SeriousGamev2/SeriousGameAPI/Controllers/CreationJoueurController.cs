using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class CreationJoueurController : ApiController
    {
        Repository r;
        public CreationJoueurController()
        {
            r = new Repository();
        }
        // GET: api/CreationJoueur
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/CreationJoueur/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet]
        [Route("api/CreateJoueur/{nom}/{prenom}")]
        public IHttpActionResult CreateJoueur(string nom, string prenom)
        {
            return Ok(r.createPlayer(nom, prenom));
        }

        [HttpGet]
        [Route("api/AddPhoto/{idPlayer}/{urlPhoto}")]
        public IHttpActionResult AddPhoto(int idPlayer, string urlPhoto)
        {
            return Ok(r.addPhoto(idPlayer, urlPhoto));
        }

        // POST: api/CreationJoueur
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CreationJoueur/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CreationJoueur/5
        public void Delete(int id)
        {
        }
    }
}
