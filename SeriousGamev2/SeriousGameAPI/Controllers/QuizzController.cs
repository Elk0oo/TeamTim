using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class QuizzController : ApiController
    {
        [HttpGet]
        [Route("api/CreateJoueur/{idEpreuve}")]
        public IHttpActionResult getQuizz(int idEpreuve)
        {
            return Ok(getQuizz(idEpreuve));
        }

        // GET: api/Quizz/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Quizz
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Quizz/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Quizz/5
        public void Delete(int id)
        {
        }
    }
}
