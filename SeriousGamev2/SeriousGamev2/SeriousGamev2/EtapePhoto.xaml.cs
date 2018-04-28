using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //appel de la méthode de reconnaissance facial
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