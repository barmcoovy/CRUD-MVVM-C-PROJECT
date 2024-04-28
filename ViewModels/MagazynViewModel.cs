using MVVM_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PROJECT.ViewModels
{
    public class MagazynViewModel : INotifyPropertyChanged
    {

        private MagazynModel _model;
        public MagazynModel Model => _model;



        public MagazynViewModel(MagazynModel model)
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


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
