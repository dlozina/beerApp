﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            // Set Datacontext for binding
            TextBoxData textBox = new TextBoxData();
            this.DataContext = textBox;
            // Disable buttons
            Bnext.IsEnabled = false;
            Bprevious.IsEnabled = false;
        }
        string strResponse = String.Empty;
        // Navigation for bottun NEXT, PREVIOUS
        private int navigation = 0;
        // Global list for memory
        private IList<BeerData.AllInfo> memory;  
        RestClient.RestClient rClient = new RestClient.RestClient();
        // VALIDATE YEAR INPUT FOR TEXT BOX

        // BUTTON GRAB ALL BEER FROM API
        private void Bgraball_Click(object sender, RoutedEventArgs e)
        {
            rClient.endPoint = "https://api.punkapi.com/v2/beers";
            // Magic - Get JSON file
            strResponse = rClient.MakeRequest();
            var data = JsonConvert.DeserializeObject<IList<BeerData.AllInfo>>(strResponse);
            memory = data;
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
            // Enable buttons to scroll trough data
            Bnext.IsEnabled = true;
            Bprevious.IsEnabled = true;
        }
        // BUTTON SEARCH BEER BY YEAR
        private void Bbyyear_Click(object sender, RoutedEventArgs e)
        {
            rClient.endPoint = "https://api.punkapi.com/v2/beers" + "?brewed_before=" + Tbyear;
            // Magic - Get JSON file
            strResponse = rClient.MakeRequest();
            var data = JsonConvert.DeserializeObject<IList<BeerData.AllInfo>>(strResponse);
            if (data.Count != 0)
            {
                memory = data;
                var byyear = data[0];
                // Data for random beer
                // Name field
                Lbeername.Content = "NAME: " + byyear.name;
                // Description
                Tbbeerdescription.Text = "DESCRIPTION: " + byyear.description;
                // First Brewd
                LfirstBrewd.Content = "FIRST BREWD: " + byyear.first_brewed;
                // ABV
                Labv.Content = "ABV: " + byyear.abv;
                // Food paring first choice
                Lfoodparing.Content = "FOOD PARING: " + byyear.food_pairing[0];
                // Beer image
                var fullFilePath = @byyear.image_url;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();
                Ibeerimage.Source = bitmap;
                // Enable buttons to scroll trough data
                Bnext.IsEnabled = true;
                Bprevious.IsEnabled = true;
            }
            else
            {
                Tbbeerdescription.Text = "NO BEER GRABED FROM API !";
            }
        }
        // BUTTON SEARCH BEER BY NAME
        private void Bbeername_Click(object sender, RoutedEventArgs e)
        {
            rClient.endPoint = "https://api.punkapi.com/v2/beers" + "?beer_name=" + Tbbeername; 
            //rClient.endPoint = "https://api.punkapi.com/v2/beers?beer_name=dog";
  
            // Magic - Get JSON file
            strResponse = rClient.MakeRequest();
            var data = JsonConvert.DeserializeObject<IList<BeerData.AllInfo>>(strResponse);
            if (data.Count != 0)
            {
                memory = data;
                var byname = data[0];
                // Data for random beer
                // Name field
                Lbeername.Content = "NAME: " + byname.name;
                // Description
                Tbbeerdescription.Text = "DESCRIPTION: " + byname.description;
                // First Brewd
                LfirstBrewd.Content = "FIRST BREWD: " + byname.first_brewed;
                // ABV
                Labv.Content = "ABV: " + byname.abv;
                // Food paring first choice
                Lfoodparing.Content = "FOOD PARING: " + byname.food_pairing[0];
                // Beer image
                var fullFilePath = @byname.image_url;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
                bitmap.EndInit();
                Ibeerimage.Source = bitmap;
                // Enable buttons to scroll trough data
                Bnext.IsEnabled = true;
                Bprevious.IsEnabled = true;
            }
            else
            {
                Tbbeerdescription.Text = "NO BEER GRABED FROM API !";
            }
        }

        private void Bprevious_Click(object sender, RoutedEventArgs e)
        {
            // Decrement data source
            if (navigation > 0)
            {
                navigation--;
                Bnext.IsEnabled = true;
            }
            else
            {
                // Lower limit
                Bprevious.IsEnabled = false;
            }

            var container = memory[navigation];
            // Data for random beer
            // Name field
            Lbeername.Content = "NAME: " + container.name;
            // Description
            Tbbeerdescription.Text = "DESCRIPTION: " + container.description;
            // First Brewd
            LfirstBrewd.Content = "FIRST BREWD: " + container.first_brewed;
            // ABV
            Labv.Content = "ABV: " + container.abv;
            // Food paring first choice
            Lfoodparing.Content = "FOOD PARING: " + container.food_pairing[0];
            // Beer image
            var fullFilePath = @container.image_url;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            Ibeerimage.Source = bitmap;
        }

        private void Brandom_Click(object sender, RoutedEventArgs e)
        {
            rClient.endPoint = "https://api.punkapi.com/v2/beers/random";
            // Magic - Get JSON file
            strResponse = rClient.MakeRequest();
            var data = JsonConvert.DeserializeObject<IList<BeerData.AllInfo>>(strResponse);
            memory = data;
            var randomdata = data[0];
            // Data for random beer
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
            // Disable buttons to scroll trough data
            Bnext.IsEnabled = false;
            Bprevious.IsEnabled = false;
        }

        private void Bnext_Click(object sender, RoutedEventArgs e)
        {
            // Increment data source
            if (navigation < memory.Count -1)
            {
                navigation++;
                Bprevious.IsEnabled = true;
            }
            else
            {
                // Lower limit
                Bnext.IsEnabled = false;
            }

            var container = memory[navigation];
            // Data for random beer
            // Name field
            Lbeername.Content = "NAME: " + container.name;
            // Description
            Tbbeerdescription.Text = "DESCRIPTION: " + container.description;
            // First Brewd
            LfirstBrewd.Content = "FIRST BREWD: " + container.first_brewed;
            // ABV
            Labv.Content = "ABV: " + container.abv;
            // Food paring first choice
            Lfoodparing.Content = "FOOD PARING: " + container.food_pairing[0];
            // Beer image
            var fullFilePath = @container.image_url;
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            Ibeerimage.Source = bitmap;
        }

    }
}
