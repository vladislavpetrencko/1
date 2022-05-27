using Mobil.ApplicationViewModel;
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
    public partial class BrigadaPage : ContentPage
    {
        public Master CurrentMaster { get; set; }
        BrigadaApplicationViewModel viewModel;
        public BrigadaPage(Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
            viewModel = new BrigadaApplicationViewModel() { Navigation = this.Navigation, CurrentMaster = CurrentMaster };
    
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetCmenaS();
            await viewModel.GetBrigadas();
            base.OnAppearing();
        }
    }
}