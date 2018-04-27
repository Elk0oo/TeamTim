
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeriousGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreationJoueur : ContentPage
	{
        Entry entryNom;
        Entry entryPrenom;
        Image imgUser;
        StackLayout stl;
		public CreationJoueur ()
		{
			InitializeComponent ();
            
            Label lblNom = new Label() { Text="Nom du joueur" };
            entryNom = new Entry() { Placeholder = "Entrez votre nom" };
            Label lblPrenom = new Label() { Text = "Prénom du joueur" };
            entryPrenom = new Entry() { Placeholder = "Entrez votre prénom" };
            imgUser = new Image();
            Button btnTake = new Button() { Text = "Prendre une photo" };
            btnTake.Clicked += BtnTake_Clicked;
            stl = new StackLayout() { Children = { lblNom,entryNom ,lblPrenom,entryPrenom,imgUser,btnTake } };
           
            this.Content = stl;
            
        }

        private async void BtnTake_Clicked(object sender, EventArgs e)
        {            
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                    return;
                }
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });
                if (file == null)
                    return;
                await DisplayAlert("File Location", file.Path, "OK");
            imgUser.Source = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
            }        
    }
}