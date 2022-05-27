using Mobil.Models;
using Mobil.Page;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.QR
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BrakPage : ContentPage
    {
        public Master CurrentMaster { get; set; }
        public BrakPage(Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new shtorka(CurrentMaster));
        }
    }
}