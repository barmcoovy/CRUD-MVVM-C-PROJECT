using MVVM_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PROJECT.ViewModels
{
     public class ZabawkaViewModel : INotifyPropertyChanged
    {
        private ZabawkaModel _model;
        public ZabawkaModel Model => _model;

        public ZabawkaViewModel(ZabawkaModel model)
        {
            _model = model;
        }

        public string Nazwa
        {
            get { return _model.Nazwa;}
            set
            {
                _model.Nazwa = value;
                OnPropertyChanged(nameof(Nazwa));
            }
        }

        public ProducentViewModel Producent
        {
            get { return new ProducentViewModel(_model.Producent); }
            set
            {
                _model.Producent = value.Model;
                OnPropertyChanged(nameof(Producent));
            }
        }
        public MagazynViewModel Magazyn
        {
            get { return new MagazynViewModel(_model.Magazyn); }
            set
            {
                _model.Magazyn = value.Model;
                OnPropertyChanged(nameof(Magazyn));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
