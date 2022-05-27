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
    public partial class ZadaniInfoPage : ContentPage
    {
        public Zadani CurrentZadani { get; set; }
        public ZadaniInfoPage(Zadani currentZadani)
        {
            InitializeComponent();
            CurrentZadani = currentZadani;
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}