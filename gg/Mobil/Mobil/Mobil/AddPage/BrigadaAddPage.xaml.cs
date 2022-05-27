using Mobil.ApplicationViewModel;
using Mobil.Models;
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
    public partial class BrigadaAddPage : ContentPage
    {
        public Master CurrentMaster { get; set; }
        public Brigada Model { get; private set; }
        public BrigadaApplicationViewModel ViewModel { get; private set; }
        public BrigadaAddPage(Brigada model,BrigadaApplicationViewModel viewModel, Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
            Model = model;
            ViewModel = viewModel;
            this.BindingContext = this;
        }
    }
}