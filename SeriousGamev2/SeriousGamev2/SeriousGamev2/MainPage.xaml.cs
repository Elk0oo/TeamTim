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
            txtErreur.IsVisible = false;
        }
        private  void btnValiderCode_Clicked(object sender, EventArgs e)
        {
            txtErreur.IsVisible = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/GetIdJeu/" + txtCodeSalle.Text.ToUpper());
            HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();

            string codeJeu = "AZER";


            if (txtCodeSalle.Text.ToUpper() == codeJeu)
            {
                App.m.codeJeu = codeJeu;
                App.m.uneEquipe = new SeriousGame.DAL.EQUIPE();
                App.m.uneEquipe.IDJEU = int.Parse(content);
               
                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/GetIdTeam/"+ App.m.uneEquipe.IDJEU);
                HttpWebResponse myResp2 = ((HttpWebResponse)(request.GetResponse()));
                var response2 = request.GetResponse();
                var reader2 = new StreamReader(response.GetResponseStream());
                string content2 = reader2.ReadToEnd();


                App.Current.MainPage = new CreationJoueur();
               
            }
            else
            {

             txtErreur.IsVisible = true;
             txtErreur.Text = "Code du jeu incorrect";
  
            }
        }
    }
}
