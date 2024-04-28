using MVVM_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PROJECT.ViewModels
{
    public class ProducentViewModel : INotifyPropertyChanged
    {
        private ProducentModel _model;
        public ProducentModel Model => _model;



        public ProducentViewModel(ProducentModel model)
        {
            _model = model;
        }

        public string Nazwa
        {
            get { return _model.Nazwa; }
            set
            {
                _model.Nazwa = value;
                OnPropertyChanged(nameof(Nazwa));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
