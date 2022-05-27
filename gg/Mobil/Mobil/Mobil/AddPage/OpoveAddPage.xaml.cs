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

namespace Mobil.AddPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpoveAddPage : ContentPage
    {
        public Master CurrentMaster { get; set; }
        public Opove Model { get; private set; }
        public OpoveApplicationViewModel ViewModel { get; private set; }

        public OpoveAddPage(Opove model, OpoveApplicationViewModel viewModel, Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
            Model = model;
            ViewModel = viewModel;
            this.BindingContext = this;
        }
    }
}