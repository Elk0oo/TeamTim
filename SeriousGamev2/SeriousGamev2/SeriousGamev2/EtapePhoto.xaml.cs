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

            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://10.3.0.46:32991/api/GetIdJeu/" + txtCodeSalle.Text.ToUpper());
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:32991/api/GetImageEtape/"+imgSelfie.Source);
            HttpWebResponse myResp = ((HttpWebResponse)(request.GetResponse()));
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            string content = reader.ReadToEnd();


        }
    }
}