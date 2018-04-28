using Newtonsoft.Json.Linq;
using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class QuizzController : ApiController
    {
        Repository r;

        public QuizzController()
        {
            r = new Repository();
        }
        [HttpGet]
        [Route("api/getQuizz")]
        public IHttpActionResult getQuizz()
        {
            return Ok(r.getQuiz());
        }

        [HttpGet]
        [Route("api/GetAdress/{lng}/{lat}")]
        public string GetAdress(string lng, string lat)
        {
            lat = lat.Replace(",", ".");
            lng = lng.Replace(",", ".");

            string url2 = "https://maps.googleapis.com/maps/api/geocode/json?latlng=" + lat + "," + lng + "&key=AIzaSyAD0SIEaMcECMwbZeUWGvHiSDiRg59keVo";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url2);
            HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var content = reader.ReadToEnd();
            //content = content.Remove(0, 409);
            //content = content.Remove(content.Length - 1, 1);
            JObject location = JObject.Parse(content);
            JToken locList = location.SelectToken("$.results[0]");
            JToken address = locList.SelectToken("$.formatted_address");
            //JToken city = locList.SelectToken("$.formattedCityLine");
            return address.ToString();
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
