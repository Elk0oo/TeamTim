using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class LogInController : ApiController
    {
        Repository r;
        // GET: api/LogIn
        public LogInController()
        {
            r = new Repository();
        }
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
         
        }
        [HttpGet]
        [Route("api/GetIdJeu")]
        public int GetIdJeu(string code)
        {
            return r.getIdJeu(code);
        }

        // POST: api/LogIn
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LogIn/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LogIn/5
        public void Delete(int id)
        {
        }
    }
}
