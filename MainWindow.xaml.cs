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
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace WpfAppExamenGSM
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


        private async void btnCancelarOperacion_Click(object sender, RoutedEventArgs e)
        {
            btnCancelarOperacion.IsEnabled = false;

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("https://api.github.com/users");
                response.EnsureSuccessStatusCode();

                if (response.IsSuccessStatusCode)
                {
                    txtRespuesta.Text = await response.Content.ReadAsStringAsync();
                    btnCancelarOperacion.IsEnabled = true;
                }
                else
                {
                    txtRespuesta.Text = $"Algo salió mal, por favor revise. {response.StatusCode}";
                    btnCancelarOperacion.IsEnabled = true;
                }
            }
        }
    }
}
