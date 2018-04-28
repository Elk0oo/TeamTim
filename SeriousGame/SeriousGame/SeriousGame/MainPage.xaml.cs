using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        private void btnValiderCode_Clicked(object sender, EventArgs e)
        {

            string faceId1 = "";
            string faceId2 = "";
            string requestBody = "{\"faceId1\":\"" + faceId1 + "\",\"faceId2\":\"" + faceId2 + "\"}";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://westcentralus.api.cognitive.microsoft.com/face/v1.0/verify%20HTTP/1.1");

            request.ContentType = "application/json";           
            request.Headers.Add("Ocp-Apim-Subscription-Key", "112d5a31c0724a0e9f459dd2a2d76d53");
            request.Method = "POST";
            request.ContentLength = requestBody.Length;





            Stream body = request.GetRequestStream();
            byte[] byteArray = Encoding.UTF8.GetBytes(requestBody);
    
            body.Write(byteArray, 0, byteArray.Length);
       

            HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();
            body.Close();


            if (txtCodeSalle.Text.ToUpper() == "IRIS")
            {
                App.Current.MainPage = new CreationJoueur();
            }
        }
    }
}
