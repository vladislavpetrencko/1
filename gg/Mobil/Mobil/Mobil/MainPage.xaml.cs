using Mobil.InfoPage;
using Mobil.Models;
using Mobil.Page;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            button1.Clicked += Button_ClickedAsync;
        }

        private async void Button_ClickedAsync(object sender, EventArgs e)
        {
            var masters = GetMaster();
            var login = log.Text;
            var password = pas.Text;
            bool check = false;
            Master currentMaster = new Master();
            foreach (var master in masters)
            {
                if (master.Логин == login && master.Пароль == password) 
                {
                    check = true;
                    currentMaster = master;
                    break;
                }
                
            }
            if (check == true) { await Navigation.PushModalAsync(new TestPage(currentMaster)); }
            else
            { await DisplayAlert("Ошибка", "Неправильный логин или пароль", "OK"); }
        }
        private List<Master> GetMaster()
        {
            var client = GetClient();
            var result = client.GetStringAsync("http://192.168.0.105:3000/api/master/").Result;

            return JsonSerializer.Deserialize<List<Master>>(result, options);
        }
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
    }
}
