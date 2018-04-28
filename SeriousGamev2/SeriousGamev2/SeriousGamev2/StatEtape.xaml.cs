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
	public partial class StatEtape : ContentPage
	{
		public StatEtape ()
		{
			InitializeComponent ();
            btnDoEtape.Clicked += BtnDoEtape_Clicked;

            App.m.uneEquipe.ID_JEU = 1;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/getEtapes/" + App.m.uneEquipe.ID_JEU);
            HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var content = reader.ReadToEnd();
        }
        async void BtnDoEtape_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new EtapePhoto();
        }
    }
}