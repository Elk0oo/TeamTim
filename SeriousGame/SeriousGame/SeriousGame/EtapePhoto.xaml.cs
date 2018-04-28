﻿using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeriousGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EtapePhoto : ContentView
	{
		public EtapePhoto ()
		{
			InitializeComponent ();

            btnTakePicture.Clicked += BtnTakePicture_Clicked;
		}

        private async void BtnTakePicture_Clicked(object sender, EventArgs e)
        {


            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
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