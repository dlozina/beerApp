using System;
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

        private void Bgraball_Click(object sender, RoutedEventArgs e)
        {
            RestClient.RestClient rClient = new RestClient.RestClient();
            rClient.endPoint = "https://api.punkapi.com/v2/beers";
            // Magic - Get JSON file
            string strResponse = String.Empty;
            strResponse = rClient.MakeRequest();
        }
    }
}
