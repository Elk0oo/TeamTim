﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SeriousGame
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            btnValiderCode.Clicked += btnValiderCode_Clicked;

        }

        private void btnValiderCode_Clicked(object sender, EventArgs e)
        {
            if (txtCodeSalle.Text.ToUpper() == "IRIS ")
            {
                App.Current.MainPage = new CreationJoueur();

            }
        }
    }
}
