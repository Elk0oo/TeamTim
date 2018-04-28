using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeriousGame
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
            InitializeComponent();
            btnValiderCode.Clicked += btnValiderCode_Clicked;

            

        }

        private async void btnValiderCode_Clicked(object sender, EventArgs e)
        {

            //string faceId1 = "2ce6646f-7ea4-431d-8a3c-7986f552ab57";
            //string faceId2 = "75c85dce-97df-4d4e-b81b-f8a34212c5b0";
            //string requestBody = "{\"faceId1\":\"" + faceId1 + "\",\"faceId2\":\"" + faceId2 + "\"}";
            //HttpContent hc = new StringContent(requestBody);
            ////HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify");
            ////request.Host = "westcentralus.api.cognitive.microsoft.com";
            ////WebClient wc = new WebClient();

            //string subscriptionKey = "112d5a31c0724a0e9f459dd2a2d76d53";


            //HttpClient client = new HttpClient();

            //// Request headers.
            ////client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            //// Request parameters. A third optional parameter is "details".
            //hc.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //hc.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
            //HttpResponseMessage response = await client.PostAsync("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify", hc);
            //// Assemble the URI for the REST API Call.
            //string res = await response.Content.ReadAsStringAsync();

          string code = 



            if (txtCodeSalle.Text.ToUpper() == "IRIS")
            {
                App.Current.MainPage = new CreationJoueur();
            }
        }
    }
}
