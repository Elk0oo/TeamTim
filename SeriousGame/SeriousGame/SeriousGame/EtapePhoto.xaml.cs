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
	public partial class EtapePhoto : ContentView
	{
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

        private void BtnTakePicture_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}