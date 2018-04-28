using Plugin.Media;
using Plugin.Media.Abstractions;
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
	public partial class CreationJoueur : ContentPage
	{
        Entry entryNom;
        Entry entryPrenom;
        Image imgUser;
        Button btnTake;
        Button btnValidate;
        Grid grid;
        MediaFile file;

        public CreationJoueur ()
		{
			InitializeComponent ();
            grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            Label lblNom = new Label() { Text = "Nom du joueur" };
            entryNom = new Entry() { };
            Label lblPrenom = new Label() { Text = "Prénom du joueur" };
            entryPrenom = new Entry() { };

            btnTake = new Button() { Text = "Prendre une photo" };
            btnTake.Clicked += BtnTake_Clicked;
            btnValidate = new Button() { Text = "Ajouter le joueur" };
            btnValidate.Clicked += BtnValidate_Clicked;
            imgUser = new Image();
            //stl = new StackLayout() { Children = { lblNom, entryNom, lblPrenom, entryPrenom, btnTake } };
            grid.Children.Add(lblNom, 0, 0);
            grid.Children.Add(entryNom, 1, 0);
            grid.Children.Add(lblPrenom, 2, 0);
            grid.Children.Add(entryPrenom, 3, 0);
            grid.Children.Add(btnTake, 0, 1);
            grid.Children.Add(imgUser, 1, 1);
            grid.Children.Add(btnValidate, 1, 2);
            this.Content = grid;
        }
        private void BtnValidate_Clicked(object sender, EventArgs e)
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            int idPLayer;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:54893/api/CreateJoueur/" + entryNom.Text + "/" + entryPrenom.Text);
                HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                string content = reader.ReadToEnd();
                idPLayer = int.Parse(content);
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                string filePath = file.Path;
                string fileName = entryNom.Text + "_" + entryPrenom.Text + "_" + idPLayer + ".png";
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://51.144.166.162/profil/" + fileName));
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Proxy = null;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential("pseudo", "Azerty@123");
                ftpRequest.KeepAlive = false;

                FileInfo ff = new FileInfo(filePath);
                byte[] fileContents = new byte[ff.Length];

                using (FileStream fr = ff.OpenRead())
                {
                    fr.Read(fileContents, 0, Convert.ToInt32(ff.Length));
                }

                using (Stream writer = ftpRequest.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                if (ftpResponse.StatusDescription == "221 Goodbye.")
                {
                    try
                    {
                        HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:54893/api/AddPhoto/" + idPLayer + "/" + entryNom.Text + "_" + entryPrenom.Text);
                        HttpWebResponse myResp2 = ((HttpWebResponse)(request2.GetResponse()));
                        var response = request2.GetResponse();
                        var reader = new StreamReader(response.GetResponseStream());
                        string content = reader.ReadToEnd();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        private async void BtnTake_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            imgUser.Source = file.Path;


        }

    }
}