﻿
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
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
        Button btnTake;
        Grid grid;
        public CreationJoueur()
        {
            InitializeComponent();
            grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            Label lblNom = new Label() { Text = "Nom du joueur" };
            entryNom = new Entry() { };
            Label lblPrenom = new Label() { Text = "Prénom du joueur" };
            entryPrenom = new Entry() {};

            btnTake = new Button() { Text = "Prendre une photo" };
            btnTake.Clicked += BtnTake_Clicked;
            imgUser = new Image();
            //stl = new StackLayout() { Children = { lblNom, entryNom, lblPrenom, entryPrenom, btnTake } };
            grid.Children.Add(lblNom, 0,0);
            grid.Children.Add(entryNom,1,0);
            grid.Children.Add(lblPrenom, 2,0);
            grid.Children.Add(entryPrenom, 3,0);
            grid.Children.Add(btnTake, 0,1);
            grid.Children.Add(imgUser, 1, 1);
            this.Content = grid;

        }

        private async void BtnTake_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Small,
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;
            
            imgUser.Source = file.Path;
           
            
        }
    }
}