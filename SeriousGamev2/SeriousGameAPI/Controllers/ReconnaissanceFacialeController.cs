using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public async void CheckFace(string faceId1, string faceId2)
        {

            string requestBody = "{\"faceId1\":\"" + faceId1 + "\",\"faceId2\":\"" + faceId2 + "\"}";
            HttpContent hc = new StringContent(requestBody);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify");
            //request.Host = "westcentralus.api.cognitive.microsoft.com";
            //WebClient wc = new WebClient();

            string subscriptionKey = "112d5a31c0724a0e9f459dd2a2d76d53";


            HttpClient client = new HttpClient();

            // Request headers.
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters. A third optional parameter is "details".
            hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            hc.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            HttpResponseMessage response = await client.PostAsync("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify", hc);
            // Assemble the URI for the REST API Call.
            string res = await response.Content.ReadAsStringAsync();


        }

        // GET: api/ReconnaissanceFaciale/5
        public string Get(int id)
        {
            return "value";
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
