using SeriousGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SeriousGamev2
{
	public partial class App : Application
	{
       public static Manager m;

		public App ()
		{
			InitializeComponent();

			MainPage = new SeriousGamev2.MainPage();
            m = new Manager();
       

        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
