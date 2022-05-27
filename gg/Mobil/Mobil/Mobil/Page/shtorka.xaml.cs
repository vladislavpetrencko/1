using Mobil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobil.Page
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class shtorka : MasterDetailPage
    {
        public Master CurrentMaster { get; set; }
        public shtorka(Master currentMaster)
        {
            InitializeComponent();
            CurrentMaster = currentMaster;
            Detail = new NavigationPage(new CmenaPage());
            IsPresented = false;
        }
        public void Button1_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new CmenaPage());
            IsPresented = false;
        }

        public void Button2_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ZadaniPage());
            IsPresented = false;
        }

        public void Button3_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new BrigadaPage(CurrentMaster));
            IsPresented = false;
        }

        public void Button4_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ConfirmationPage(CurrentMaster));
            IsPresented = false;
        }

        public void Button5_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new OpovePage(CurrentMaster));
            IsPresented = false;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());
        }
    }
}