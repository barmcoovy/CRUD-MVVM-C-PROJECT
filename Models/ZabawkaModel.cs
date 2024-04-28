using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_PROJECT.Models
{
    public class ZabawkaModel
    {
        public string Nazwa { get; set; }
        
        public ProducentModel Producent { get; set; }
        public MagazynModel Magazyn { get; set; }
    }
}
