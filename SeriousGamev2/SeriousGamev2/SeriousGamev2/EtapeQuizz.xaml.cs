using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeriousGamev2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtapeQuizz : ContentPage
	{
		public EtapeQuizz ()
		{
			InitializeComponent ();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.googleapis.com/geolocation/v1/geolocate?key=AIzaSyAF-EmY3jcwPxRCsy1cTCvLDUoFCoay1jM");
            request.Method = "POST";
            request.ContentLength = 0;
            HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();
            JObject result = JObject.Parse(content);
            string lat = result.SelectToken("$.location.lat").ToString();
            string longi = result.SelectToken("$.location.lng").ToString();

            
            lat = lat.Replace(".", ",");
            longi = longi.Replace(".", ",");


            HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/GetAdress/" + longi + "/" + lat);
            HttpWebResponse myResp2 = ((HttpWebResponse)(request2.GetResponse()));
            var response2 = request2.GetResponse();
            var reader2 = new StreamReader(response2.GetResponseStream());
            string content2 = reader2.ReadToEnd();
            QUIZZ quiz = JsonConvert.DeserializeObject<QUIZZ>(content2);
            txtQuestion.Text = quiz.QUESTION;
            txtReponse1.Text = quiz.REPONSE1;
            txtReponse2.Text = quiz.REPONSE2;
            txtReponse3.Text = quiz.REPONSE3;
            txtReponse4.Text = quiz.REPONSE4;



        }
	}
}