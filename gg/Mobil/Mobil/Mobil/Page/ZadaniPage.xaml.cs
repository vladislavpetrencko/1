using Mobil.InfoPage;
using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ZadaniPage : ContentPage
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        public List<Zadani> Zadanis { get; set; }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public ZadaniPage()
        {
            InitializeComponent();
            Zadanis = GetZadani();
            IstZadanis.ItemsSource = Zadanis;
            BindingContext = this;
        }
        private List<Zadani> GetZadani()
        {
            var client = GetClient();
            var result = client.GetStringAsync("http://192.168.0.105:3000/api/zadani/").Result;

            return JsonSerializer.Deserialize<List<Zadani>>(result, options);
        }

        private async void IstZadanis_ItemTapped1(object sender, ItemTappedEventArgs e)
        {
            var currentZadani = e.Item as Zadani;
            var zadaniInfoPage = new ZadaniInfoPage(currentZadani);
            await Navigation.PushAsync(zadaniInfoPage);

        }
    }
}