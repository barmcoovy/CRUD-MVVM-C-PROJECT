using MVVM_PROJECT.Models;
using MVVM_PROJECT.Utils;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;


namespace MVVM_PROJECT.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Random random = new Random();

        public ObservableCollection<ZabawkaViewModel> Zabawki { get; set; }

        public ObservableCollection<MagazynViewModel> Magazyny { get; set; }


        public ObservableCollection<ProducentViewModel> Producenci { get; set; }

        private bool _czyTrybEdycji;

        public bool CzyTrybEdycji
        {
            get => _czyTrybEdycji;
            set
            {
                _czyTrybEdycji = value;
                OnPropertyChanged(nameof(CzyTrybEdycji));
            }
        }

        public string Nazwa { get; set; }
        public MagazynViewModel WybranyMagazyn { get; set; }
        public ProducentViewModel WybranyProducent { get; set; }

        public ZabawkaViewModel ZaznaczonaZabawka { get; set; }

        private ZabawkaViewModel _edytujZabawke;

        public ZabawkaViewModel EdycjaZabawka
        {
            get => _edytujZabawke;
            set
            {
                _edytujZabawke = value;
                OnPropertyChanged(nameof(EdycjaZabawka));
            }
        }

        public ICommand DodajZabawkeCommand { get; }
        public ICommand GenerujZabawkiCommand { get; }
        public ICommand UsunZabawkeCommand { get; }
        public ICommand EdytujZabawkeCommand { get; }
        public ICommand ZapiszZmianyCommand { get; }
        public ICommand AnulujZmianyCommand { get; }

        public MainWindowViewModel()
        {
            Zabawki = new ObservableCollection<ZabawkaViewModel>();
            Magazyny = new ObservableCollection<MagazynViewModel>();
            Producenci = new ObservableCollection<ProducentViewModel>();

            DodajZabawkeCommand = new RelayCommand(DodajZabawke, CzyMoznaDodacZabawke);
            GenerujZabawkiCommand = new RelayCommand(GenerujLosoweZabawki);
            UsunZabawkeCommand = new RelayCommand(UsunZabawke, CzyZabawkaZaznaczona);
            EdytujZabawkeCommand = new RelayCommand(EdytujZabawke, CzyZabawkaZaznaczona);
            ZapiszZmianyCommand = new RelayCommand(ZapiszZmiany, CzyMoznaZapisacZmiany);
            AnulujZmianyCommand = new RelayCommand(AnulujZmiany);

            CzyTrybEdycji = false;

            WczytajDane();

        }
        
        public void AnulujZmiany()
        {
            
            EdycjaZabawka.Nazwa = Nazwa;
            EdycjaZabawka.Magazyn = WybranyMagazyn;
            EdycjaZabawka.Producent = WybranyProducent;

            CzyTrybEdycji = false;
        }
        public void ZapiszZmiany()
        {
            CzyTrybEdycji = false;
        }
        public bool CzyMoznaZapisacZmiany()
        {
            return EdycjaZabawka != null;
        }

        public void DodajZabawke()
        {
            Zabawki.Add(new ZabawkaViewModel(new ZabawkaModel
            {
                Nazwa = Nazwa,
                Producent = WybranyProducent.Model,
                Magazyn = WybranyMagazyn.Model
            }));
        }

        public bool CzyMoznaDodacZabawke()
        {
            if (string.IsNullOrWhiteSpace(Nazwa)) return false;
            if (WybranyProducent == null) return false;
            if (WybranyMagazyn == null) return false;
            return true;
        }

        public void EdytujZabawke()
        {
            
            EdycjaZabawka = ZaznaczonaZabawka;
            CzyTrybEdycji = true;
            Nazwa = ZaznaczonaZabawka.Nazwa;
            WybranyProducent = ZaznaczonaZabawka.Producent;
            WybranyMagazyn = ZaznaczonaZabawka.Magazyn;
            


        }

        public void UsunZabawke()
        {
            MessageBoxResult czyUsuwac = MessageBox.Show("Czy napewno chcesz usunąć zabawkę?", "Potwierdzenie usunięcia zabawki", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(czyUsuwac ==  MessageBoxResult.Yes)
            {
                Zabawki.Remove(ZaznaczonaZabawka);
            }
            
        }
        public bool CzyZabawkaZaznaczona()
        {
            return ZaznaczonaZabawka != null;
        }

        private void WczytajDane()
        {
            Magazyny.Add(new MagazynViewModel(new MagazynModel { Nazwa = "Poznań"}));
            Magazyny.Add(new MagazynViewModel(new MagazynModel { Nazwa = "Wrocław"}));
            Magazyny.Add(new MagazynViewModel(new MagazynModel { Nazwa = "Kraków"}));
            Magazyny.Add(new MagazynViewModel(new MagazynModel { Nazwa = "Warszawa"}));
            Magazyny.Add(new MagazynViewModel(new MagazynModel { Nazwa = "Zielona Góra"}));

            Producenci.Add(new ProducentViewModel(new ProducentModel { Nazwa = "Fajowe Zabawki" }));
            Producenci.Add(new ProducentViewModel(new ProducentModel { Nazwa = "Zabawki Eleganckie Tego Typu" }));
            Producenci.Add(new ProducentViewModel(new ProducentModel { Nazwa = "Eine Gute Zabawki" }));
        }

        private void GenerujLosoweZabawki()
        {
            string[] nazwyZabawek = { "Pluszak", "Kostka Rubika", "Lego", "Puzzle" };
            for(int i = 0; i < 10; i++)
            {
                string nazwaZabawki = nazwyZabawek[random.Next(nazwyZabawek.Length)];
                ProducentViewModel losowyProducent = Producenci[random.Next(Producenci.Count)];
                MagazynViewModel losowyMagazyn = Magazyny[random.Next(Magazyny.Count)];

                Zabawki.Add(new ZabawkaViewModel(new ZabawkaModel
                {
                    Nazwa = nazwaZabawki,
                    Producent = losowyProducent.Model,
                    Magazyn = losowyMagazyn.Model
                })) ;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
