using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SeriousGameAPI.Controllers
{
    public class ReconnaissanceFacialeController : ApiController
    {
        // GET: api/ReconnaissanceFaciale
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ReconnaissanceFaciale/5
        [Route("api/RecoFacial")]
        [HttpPost]
        public string CheckFace()
        {
            string faceId1 = "";
            string faceId2 = "";
            string requestBody = "{\"faceId1\":\"" + faceId1 + "\",\"faceId2\":\"" + faceId2 + "\"}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify%20HTTP/1.1");
            request.Method = "POST";
            request.ContentLength = 0;


            request.Headers.Add("Content-Type", "application/json");
            request.Headers.Add("Ocp-Apim-Subscription-Key", "112d5a31c0724a0e9f459dd2a2d76d53");



            Stream body =  request.GetRequestStream();
            byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
            body.Write(byteArray, 0, byteArray.Length);
            body.Close();

            HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();
            JObject result = JObject.Parse(content);
            return "";
        }

        // POST: api/ReconnaissanceFaciale
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ReconnaissanceFaciale/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ReconnaissanceFaciale/5
        public void Delete(int id)
        {
        }
    }
}
