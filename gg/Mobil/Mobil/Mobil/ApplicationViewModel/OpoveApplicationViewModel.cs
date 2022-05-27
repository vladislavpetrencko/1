using Mobil.AddPage;
using Mobil.Models;
using Mobil.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobil.ApplicationViewModel
{
    public class OpoveApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   
        Opove selectedOpove;  
        private bool isBusy;    
        public Master CurrentMaster { get; set; }
        private ObservableCollection<Cmena> cmenaS;
        public ObservableCollection<Opove> Opoves { get; set; }
        OpoveService opoveService = new OpoveService();
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Cmena> CmenaS
        {
            get => cmenaS;
            set
            {
                cmenaS = value;
                OnPropertyChanged("CmenaS");

            }
        }
        public Cmena Selected1 { get; set; } = new Cmena();
        public ICommand CreateOpoveCommand { protected set; get; }
        public ICommand DeleteOpoveCommand { protected set; get; }
        public ICommand SaveOpoveCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation1 { get; set; }

        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                OnPropertyChanged("IsLoaded");
            }
        }
        public bool IsLoaded
        {
            get { return !isBusy; }
        }

        public OpoveApplicationViewModel()
        {
            Opoves = new ObservableCollection<Opove>();
            IsBusy = false;
            CreateOpoveCommand = new Command(CreateOpove);
            DeleteOpoveCommand = new Command(DeleteOpove);
            SaveOpoveCommand = new Command(SaveOpove);
            BackCommand = new Command(Back);
        }

        public Opove SelectedOpove
        {
            get { return selectedOpove; }
            set
            {
                if (selectedOpove != value)
                {
                    Opove tempOpove = new Opove()
                    {
                        id_zaiv = value.id_zaiv,
                        НомерСтанка = value.НомерСтанка,
                        ФИОработника = value.ФИОработника,
                        ОписаниеПоломки = value.ОписаниеПоломки,
                        id_master = value.id_master
                        
                    };
                    selectedOpove = value;
                    OnPropertyChanged("SelectedOpove");
                    if (selectedOpove != null)
                    {

                        Selected1 = (from person in CmenaS
                                     where person.Сокращение == selectedOpove.ФИОработника
                                     select person).FirstOrDefault();
                    }
                        Navigation1.PushAsync(new OpoveAddPage(tempOpove, this, CurrentMaster));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateOpove()
        {
            await Navigation1.PushAsync(new OpoveAddPage(new Opove(), this, CurrentMaster));
        }
        private void Back()
        {
            Navigation1.PopAsync();
        }

        public async Task GetOpoves()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Opove> opoves = await opoveService.Get();

            
            while (Opoves.Any())
                Opoves.RemoveAt(Opoves.Count - 1);

            
            foreach (Opove f in opoves)
                Opoves.Add(f);
            IsBusy = false;
            initialized = true;
        }
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
        public async Task<ObservableCollection<Cmena>> GetCmenaS()
        {
            try
            {
                var client = GetClient();
                var result = await client.GetAsync("http://192.168.0.105:3000/api/cmena").Result.Content.ReadAsStringAsync();
                client.Dispose();
                CmenaS = JsonSerializer.Deserialize<ObservableCollection<Cmena>>(result, options);
                return CmenaS;

            }
            catch (Exception ex)
            {
                return new ObservableCollection<Cmena>();
            }
        }
        private async void SaveOpove(object opoveObject)
        {
            Opove opove = opoveObject as Opove;
            if (Selected1 != null) opove.ФИОработника = Selected1.Сокращение;
            opove.id_master = CurrentMaster.id_master;
            if (opove != null)
            {
                IsBusy = true;
                
                if (opove.id_zaiv > 0)
                {
                    Opove updatedOpove = await opoveService.Update(opove);
                    
                    if (updatedOpove != null)
                    {
                        int pos = Opoves.IndexOf(updatedOpove);
                        Opoves.RemoveAt(pos);
                        Opoves.Insert(pos, updatedOpove);
                    }
                }
                
                else
                {
                    Opove addedOpove = await opoveService.Add(opove);
                    if (addedOpove != null)
                        Opoves.Add(addedOpove);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteOpove(object opoveObject)
        {
            Opove opove = opoveObject as Opove;
            if (opove != null)
            {
                IsBusy = true;
                Opove deletedOpove = await opoveService.Delete(opove.id_zaiv);
                if (deletedOpove != null)
                {
                    Opoves.Remove(deletedOpove);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}
