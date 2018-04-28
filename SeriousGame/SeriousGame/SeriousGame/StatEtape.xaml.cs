﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeriousGame
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatEtape : ContentPage
	{
		public StatEtape ()
		{
			InitializeComponent ();

            btnDoEtape.Clicked += BtnDoEtape_Clicked;
		}

        async void BtnDoEtape_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EtapeQuizz());
        }
    }
}