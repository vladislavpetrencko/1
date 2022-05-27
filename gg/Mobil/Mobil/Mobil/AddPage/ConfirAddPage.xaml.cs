using Mobil.Models;
using Mobil.Page;
using Mobil.QR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.AddPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConfirAddPage : ContentPage
    {
        public Master CurrentMaster { get; set; }
        public ConfirAddPage(Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
        }

        private  void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Сканер QR-кода", "QR-код успешно отсканирован!", "ОК");

            });
        }

        private async void Button_ClickedSklad(object sender, EventArgs e)
        {
            
            await Navigation.PushModalAsync(new shtorka(CurrentMaster));
        }

        private async void Button_ClickedBrak(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BrakPage(CurrentMaster));
        }
    }
}