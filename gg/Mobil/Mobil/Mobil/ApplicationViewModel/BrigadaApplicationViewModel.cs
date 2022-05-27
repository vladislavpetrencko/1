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
    public class BrigadaApplicationViewModel : INotifyPropertyChanged
    {
        bool initialized = false;   // была ли начальная инициализация
        Brigada selectedBrigada;  
        private bool isBusy;    // идет ли загрузка с сервера
        public Master CurrentMaster { get; set; }
        private ObservableCollection<Cmena> cmenaS;
        public ObservableCollection<Brigada> Brigadas { get; set; }
        BrigadaService brigadaService = new BrigadaService();
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
        public Cmena Selected2 { get; set; } = new Cmena();
        public Cmena Selected3 { get; set; } = new Cmena();
        public Cmena Selected4 { get; set; } = new Cmena();
        public Cmena Selected5 { get; set; } = new Cmena();
        public Cmena Selected6 { get; set; } = new Cmena();
        public ICommand CreateBrigadaCommand { protected set; get; }
        public ICommand DeleteBrigadaCommand { protected set; get; }
        public ICommand SaveBrigadaCommand { protected set; get; }
        public ICommand BackCommand { protected set; get; }

        public INavigation Navigation { get; set; }

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

        public BrigadaApplicationViewModel()
        {
            Brigadas = new ObservableCollection<Brigada>();
            IsBusy = false;
            CreateBrigadaCommand = new Command(CreateBrigada);
            DeleteBrigadaCommand = new Command(DeleteBrigada);
            SaveBrigadaCommand = new Command(SaveBrigada);
            BackCommand = new Command(Back);
            
        }
        
        public Brigada SelectedBrigada
        {
            get { return selectedBrigada; }
            set
            {
                if (selectedBrigada != value)
                {
                    Brigada tempBrigada = new Brigada()
                    {
                        id_brigada = value.id_brigada,
                        Название = value.Название,
                        Бригадир = value.Бригадир,
                        Раб1 = value.Раб1,
                        Раб2 = value.Раб2,
                        Раб3 = value.Раб3,
                        Раб4 = value.Раб4,
                        Раб5 = value.Раб5
                    };
                    selectedBrigada = value;
                    OnPropertyChanged("SelectedBrigada");
                    if (selectedBrigada != null)
                    {

                        Selected1 = (from person in CmenaS
                                     where person.Сокращение == selectedBrigada.Бригадир
                                     select person).FirstOrDefault();
                        Selected2 = (from person in CmenaS
                                     where person.Сокращение == selectedBrigada.Раб1
                                     select person).FirstOrDefault();
                        Selected3 = (from person in CmenaS
                                     where person.Сокращение == selectedBrigada.Раб2
                                     select person).FirstOrDefault();
                        Selected4 = (from person in CmenaS
                                     where person.Сокращение == selectedBrigada.Раб3
                                     select person).FirstOrDefault();
                        Selected5 = (from person in CmenaS
                                     where person.Сокращение == selectedBrigada.Раб4
                                     select person).FirstOrDefault();
                        Selected6 = (from person in CmenaS
                                     where person.Сокращение == selectedBrigada.Раб5
                                     select person).FirstOrDefault();
                    }
                    Navigation.PushAsync(new BrigadaAddPage(tempBrigada, this, CurrentMaster));
                }
            }
        }
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private async void CreateBrigada()
        {
            await Navigation.PushAsync(new BrigadaAddPage(new Brigada(), this, CurrentMaster));
        }
        private void Back()
        {
            Navigation.PopAsync();
        }

        public async Task GetBrigadas()
        {
            if (initialized == true) return;
            IsBusy = true;
            IEnumerable<Brigada> brigadas = await brigadaService.Get();

            // очищаем список
            
            while (Brigadas.Any())
                Brigadas.RemoveAt(Brigadas.Count - 1);

            // добавляем загруженные данные
            foreach (Brigada f in brigadas)
                Brigadas.Add(f);
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

        private async void SaveBrigada(object brigadaObject)
        {
            Brigada brigada = brigadaObject as Brigada;
            if (Selected1!=null) brigada.Бригадир = Selected1.Сокращение;
            if (Selected2 != null) brigada.Раб1 = Selected2.Сокращение;
            if (Selected3 != null) brigada.Раб2 = Selected3.Сокращение;
            if (Selected4 != null) brigada.Раб3 = Selected4.Сокращение;
            if (Selected5 != null) brigada.Раб4 = Selected5.Сокращение;
            if (Selected6 != null) brigada.Раб5 = Selected6.Сокращение;
            if (brigada != null)
            {
                IsBusy = true;
                // редактирование
                if (brigada.id_brigada > 0)
                {
                    Brigada updatedBrigada = await brigadaService.Update(brigada);
                    // заменяем объект в списке на новый
                    if (updatedBrigada != null)
                    {
                        int pos = Brigadas.IndexOf(updatedBrigada);
                        Brigadas.RemoveAt(pos);
                        Brigadas.Insert(pos, updatedBrigada);
                    }
                }
                // добавление
                else
                {
                    Brigada addedBrigada = await brigadaService.Add(brigada);
                    if (addedBrigada != null)
                        Brigadas.Add(addedBrigada);
                }
                IsBusy = false;
            }
            Back();
        }
        private async void DeleteBrigada(object brigadaObject)
        {
            Brigada brigada = brigadaObject as Brigada;
            if (brigada != null)
            {
                IsBusy = true;
                Brigada deletedBrigada = await brigadaService.Delete(brigada.id_brigada);
                if (deletedBrigada != null)
                {
                    Brigadas.Remove(deletedBrigada);
                }
                IsBusy = false;
            }
            Back();
        }
    }
}
