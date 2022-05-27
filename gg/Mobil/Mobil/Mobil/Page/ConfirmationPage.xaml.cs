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
    public partial class ConfirmationPage : ContentPage
    {

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public List<Zadani> Zadanis { get; set; }
        public Master CurrentMaster { get; set; }
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public ConfirmationPage(Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
            Load();
            BindingContext = this;
        }
        private async Task<List<Zadani>> GetZadani()
        {
            try
            {
                var client = GetClient();
                var result = await client.GetAsync("http://192.168.0.105:3000/api/zadani/").Result.Content.ReadAsStringAsync();
                client.Dispose();
                return JsonSerializer.Deserialize<List<Zadani>>(result, options);
            }
            catch (Exception ex)
            {
                return new List<Zadani>();
            }
        }

        private async void IstZadanis_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var currentConfirmation = e.Item as Zadani;
            var confirmationInfoPage = new ConfirmationInfoPage(currentConfirmation);
            
            await Navigation.PushModalAsync(confirmationInfoPage);
        }

        private async void Load ()
        {
            Zadanis = await GetZadani();
            IstZadanis.ItemsSource = Zadanis;

        }
    }

}