using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Mobil.InfoPage;

namespace Mobil.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CmenaPage : ContentPage
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        public List<Cmena> Cmenas { get; set; }

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public CmenaPage()
        {
            InitializeComponent();
            Load();
            BindingContext = this;
        }
        private  List<Cmena> GetCmena()
        {
            var client = GetClient();
            var result =  client.GetStringAsync("http://192.168.0.105:3000/api/cmena").Result;
             return JsonSerializer.Deserialize<List<Cmena>>(result, options);
            //try
            //{
            //    var client = GetClient();
            //    var result = await client.GetAsync("http://192.168.0.105:3000/api/cmena").Result.Content.ReadAsStringAsync();
            //    client.Dispose();
            //    return JsonSerializer.Deserialize<List<Cmena>>(result, options);
            //}
            //catch (Exception ex)
            //{
            //    return new List<Cmena>();
            //}
        }

        private async void IstCmenas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var currentCmena = e.Item as Cmena;
            var cmenaInfoPage = new CmenaInfoPage(currentCmena);
            await Navigation.PushAsync(cmenaInfoPage);

        }
        private async void Load()
        {
            Cmenas =  GetCmena();
            IstCmenas.ItemsSource = Cmenas;

        }
    }
}