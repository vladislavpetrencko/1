using Mobil.AddPage;
using Mobil.Models;
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
    public partial class ConfirmationInfoPage : ContentPage
    {
        public Master CurrentMaster { get; set; }
        public Zadani CurrentConfirmation { get; set; }
        public ConfirmationInfoPage(Zadani currentConfirmation)
        {
            InitializeComponent();
            CurrentConfirmation = currentConfirmation;
            BindingContext = this;
        }

        public ConfirmationInfoPage(Master currentMaster)
        {
            CurrentMaster = currentMaster;
            
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ConfirAddPage(CurrentMaster));
        }
    }
                    
}




