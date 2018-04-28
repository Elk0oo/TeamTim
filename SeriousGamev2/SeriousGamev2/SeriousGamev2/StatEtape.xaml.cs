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
	public partial class StatEtape : ContentPage
	{
		public StatEtape ()
		{
			InitializeComponent ();
            btnDoEtape.Clicked += BtnDoEtape_Clicked;
        }
        async void BtnDoEtape_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new EtapePhoto();
        }
    }
}