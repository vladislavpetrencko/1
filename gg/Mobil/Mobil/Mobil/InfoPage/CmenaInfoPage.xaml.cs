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
    public partial class CmenaInfoPage : ContentPage
    { 
        public Cmena CurrentCmena {get; set;}

        public CmenaInfoPage(Cmena currentCmena)
        {
            InitializeComponent();
            CurrentCmena = currentCmena;
            BindingContext = this;
        }
    }
}