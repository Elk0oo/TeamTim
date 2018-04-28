using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeriousGamev2
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            btnValiderCode.Clicked += btnValiderCode_Clicked;
        }
        private  void btnValiderCode_Clicked(object sender, EventArgs e)
        {


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:54893/api/GetIdJeu/"+ txtCodeSalle.Text.ToUpper());
            HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();

            string codeJeu = "IRIS";


            if (txtCodeSalle.Text.ToUpper() == codeJeu)
            {
                App.m.codeJeu = codeJeu;
                App.m.uneEquipe.IDJEU = int.Parse(content);
                
                  App.Current.MainPage = new CreationJoueur();
               
            }
        }
    }
}
