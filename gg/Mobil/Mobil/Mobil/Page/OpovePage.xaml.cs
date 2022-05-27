using Mobil.ApplicationViewModel;
using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpovePage : ContentPage
    {
        OpoveApplicationViewModel viewModel;
        public Master CurrentMaster { get; set; }
        public OpovePage(Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
            viewModel = new OpoveApplicationViewModel() { Navigation1 = this.Navigation, CurrentMaster = currentMaster };
            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            await viewModel.GetCmenaS();
            await viewModel.GetOpoves();
            base.OnAppearing();
        }

    }
}