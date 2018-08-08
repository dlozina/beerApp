﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using beerApp.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace beerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string strResponse = String.Empty;
        RestClient.RestClient rClient = new RestClient.RestClient();

        private void Bgraball_Click(object sender, RoutedEventArgs e)
        {
            rClient.endPoint = "https://api.punkapi.com/v2/beers";
            // Magic - Get JSON file
            strResponse = rClient.MakeRequest();
            var data = JsonConvert.DeserializeObject<IList<BeerData.AllInfo>>(strResponse);
            var firstBeer = data[0];
            // Name field
            Lbeername.Content = "NAME: " + firstBeer.name;
            // Description
            Tbbeerdescription.Text = "DESCRIPTION: " + firstBeer.description;
            // First Brewd
            LfirstBrewd.Content = "FIRST BREWD: " + firstBeer.first_brewed;
            // ABV
            Labv.Content = "ABV: " + firstBeer.abv;
            // Food paring first choice
            Lfoodparing.Content = "FOOD PARING: " + firstBeer.food_pairing[0];
            // Beer image
            var fullFilePath = @firstBeer.image_url;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            Ibeerimage.Source = bitmap;
        }

        private void Bprevious_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Brandom_Click(object sender, RoutedEventArgs e)
        {
            rClient.endPoint = "https://api.punkapi.com/v2/beers/random";
            // Magic - Get JSON file
            strResponse = rClient.MakeRequest();
            var data = JsonConvert.DeserializeObject<IList<BeerData.AllInfo>>(strResponse);
            var randomdata = data[0];
            //
            // Name field
            Lbeername.Content = "NAME: " + randomdata.name;
            // Description
            Tbbeerdescription.Text = "DESCRIPTION: " + randomdata.description;
            // First Brewd
            LfirstBrewd.Content = "FIRST BREWD: " + randomdata.first_brewed;
            // ABV
            Labv.Content = "ABV: " + randomdata.abv;
            // Food paring first choice
            Lfoodparing.Content = "FOOD PARING: " + randomdata.food_pairing[0];
            // Beer image
            var fullFilePath = @randomdata.image_url;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            Ibeerimage.Source = bitmap;
        }

        private void Bnext_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}