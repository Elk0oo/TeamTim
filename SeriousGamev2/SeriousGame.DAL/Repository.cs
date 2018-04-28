using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SeriousGame.DAL
{
    public class Repository
    {
        teamtimEntities _context;
        string resultIdentification = "";

        public Repository()
        {
            _context = new teamtimEntities();
            _context.Database.Log = (message) => Debug.WriteLine(message);
            _context.Configuration.ProxyCreationEnabled = true;
            _context.Configuration.LazyLoadingEnabled = false;
        }

        public int AddIdEquipe(int idJeu)
        {
            _context.EQUIPEs.Add(new EQUIPE() { ID_JEU = idJeu});
            return  _context.SaveChanges(); 
        }

        public string GetImageEtape(string imgEtape,int idPlayer)
        {

            JOUEUR joueur = _context.JOUEURs.FirstOrDefault(j => j.ID == idPlayer-1);
           
            string imgProfil = joueur.PHOTO;
            string imgAValider = imgEtape;



            checkFace(imgProfil, imgAValider);

            if (true)
            {
                return "";
            }

        
        }

        private async void checkFace(string imgProfil, string imgAValider)
        {

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(imgProfil);
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.  
            request.Credentials = new NetworkCredential("TeamTim", "Azerty@2018!");

            FtpWebResponse responseh = (FtpWebResponse)request.GetResponse();

            Stream responseStream = responseh.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
        

            reader.Close();
            responseh.Close();




            string requestBody = "{\"url\":\"" + imgProfil + "\"}";
            HttpContent hc = new StringContent(requestBody);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false");
            //request.Host = "westcentralus.api.cognitive.microsoft.com";
            //WebClient wc = new WebClient();

            string subscriptionKey = "112d5a31c0724a0e9f459dd2a2d76d53";


            HttpClient client = new HttpClient();

            // Request headers.
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters. A third optional parameter is "details".
            hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            hc.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            HttpResponseMessage response = await client.PostAsync("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false", hc);
            // Assemble the URI for the REST API Call.
            string res = await response.Content.ReadAsStringAsync();



            string requestBody2 = "{\"url\":\"" + imgAValider + "\"}";
            HttpContent hc2 = new StringContent(requestBody);
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false");
            //request.Host = "westcentralus.api.cognitive.microsoft.com";
            //WebClient wc = new WebClient();

            string subscriptionKey2 = "112d5a31c0724a0e9f459dd2a2d76d53";


            HttpClient client2 = new HttpClient();

            // Request headers.
            //client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // Request parameters. A third optional parameter is "details".
            hc2.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            hc2.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            HttpResponseMessage response2 = await client2.PostAsync("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/detect?returnFaceId=true&returnFaceLandmarks=false", hc2);
            // Assemble the URI for the REST API Call.
            string res2 = await response2.Content.ReadAsStringAsync();







        }

        public int GetIdEquipe(int idJeu)
        {
            return _context.EQUIPEs.Select(eq => eq.ID_JEU == idJeu).Count();
        }

        public int createPlayer(string nom, string prenom, int idEquipe)
        {
            _context.JOUEURs.Add(new JOUEUR() { NOM = nom, PRENOM = prenom,ID_EQUIPE=idEquipe });
            _context.SaveChanges();

            var result = _context.JOUEURs.Max(je => je.ID);
            return result;
        }
        public int addPhoto(int idPlayer, string filename)
        {

            JOUEUR j = (JOUEUR)(_context.JOUEURs.FirstOrDefault(joueur => joueur.ID == idPlayer));
            j.PHOTO = "ftp://51.144.166.162/profil/" + filename +"_"+ idPlayer+".png";
            return _context.SaveChanges();
        }

        public int getIdJeu(string code)
        {
            return ((JEU)(_context.JEUs.FirstOrDefault(jeu => jeu.CODE == code))).ID;
        }

        public List<ETAPE> getEtapes(int idJeu)
        {
            List<ETAPE> etapes = new List<ETAPE>();
            etapes = _context.ETAPEs.Where(etape => etape.ID_JEU == idJeu).ToList();
            return etapes;
        }
        public QUIZZ getQuiz()
        {            
            var r = new Random();
            
            var quizzList = _context.QUIZZs.ToList();

            return quizzList.ElementAt(r.Next(0,quizzList.Count()-1));
        }
    }
}
