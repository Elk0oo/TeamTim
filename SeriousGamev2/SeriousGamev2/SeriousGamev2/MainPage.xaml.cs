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
                App.m.uneEquipe.ID_JEU = int.Parse(content);

                HttpWebRequest request3 = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/AddIdEquipe/" + App.m.uneEquipe.ID_JEU);
                HttpWebResponse myResp3 = ((HttpWebResponse)(request3.GetResponse()));
                var response3 = request3.GetResponse();
                var reader3 = new StreamReader(response3.GetResponseStream());
                string content3 = reader3.ReadToEnd();

                HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/GetIdEquipe/" + App.m.uneEquipe.ID_JEU);
                HttpWebResponse myResp2 = ((HttpWebResponse)(request2.GetResponse()));
                var response2 = request2.GetResponse();
                var reader2 = new StreamReader(response2.GetResponseStream());
                string content2 = reader2.ReadToEnd();

                App.m.uneEquipe.ID = int.Parse(content2);

               


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
