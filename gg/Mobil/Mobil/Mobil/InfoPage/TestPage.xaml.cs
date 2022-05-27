using Mobil.Models;
using Mobil.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.InfoPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestPage : ContentPage
    {
        public Master CurrentMaster { get; set; }
        public TestPage(Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
        }

     
        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool check = false;
            if (r1.IsChecked == true && r2.IsChecked == true && r3.IsChecked == true && r4.IsChecked == true && r5.IsChecked == true) 
            { 
                check = true; 
            }
            if (check == true)
            { 
                await Navigation.PushModalAsync(new shtorka(CurrentMaster)); 
            }
            else 
            {
                await DisplayAlert("Тест не пройден", "Исправте ошибки", "OK"); 
            }
        }
    }
}