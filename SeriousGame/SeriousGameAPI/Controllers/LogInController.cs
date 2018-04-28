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

        public LogInController()
        {
            r = new Repository();
        }
        // GET: api/LogIn
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/CheckCode")]
        public string CheckCode()
        {
            return r.getCodeJeu();
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
