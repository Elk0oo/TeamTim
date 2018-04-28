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
	public partial class EtapePhoto : ContentPage
	{
        MediaFile file;
        public EtapePhoto ()
		{
			InitializeComponent ();
            btnTakePicture.Clicked += BtnTakePicture_Clicked;
            btnValiderPicture.Clicked += btnValiderPicture_Clicked;
        }
        private void btnValiderPicture_Clicked(object sender, EventArgs e)
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            int idPLayer;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/CreateJoueur/iwjwkt/h/" + App.m.uneEquipe.ID);
                //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:32991/api/CreateJoueur/" + entryNom.Text + "/" + entryPrenom.Text + "/" + App.m.uneEquipe.ID);
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
                string fileName = "PhotoAValider" + idPLayer + ".png";
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://51.144.166.162/EtapePhoto/" + fileName));
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpRequest.Proxy = null;
                ftpRequest.UseBinary = true;
                ftpRequest.Credentials = new NetworkCredential("TeamTim", "Azerty@2018!");
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
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/GetImageEtape/PhotoAValider" + idPLayer+"/"+ idPLayer);
                        //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:32991/api/GetImageEtape/"+imgSelfie.Source);
                        HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
                        var response = request.GetResponse();
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

        private async void BtnTakePicture_Clicked(object sender, EventArgs e)
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

            imgSelfie.Source = file.Path;

            


        }
    }
}