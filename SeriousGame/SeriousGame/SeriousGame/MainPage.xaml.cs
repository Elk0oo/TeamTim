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


           //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:54893/api/CheckCode");
           // HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
           // var response = request.GetResponse();
           // var reader = new StreamReader(response.GetResponseStream());
           // string content = reader.ReadToEnd();



            if (txtCodeSalle.Text.ToUpper() == "IRIS")
            {
                App.Current.MainPage = new CreationJoueur();
            }
        }
    }
}
