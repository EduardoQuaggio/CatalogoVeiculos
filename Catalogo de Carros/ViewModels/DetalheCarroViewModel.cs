using Catalogo_de_Carros.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalogo_de_Carros.ViewModels
{
    public partial class DetalheCarroViewModel : ObservableObject
    {
        [ObservableProperty]
        private Car _car;
        public DetalheCarroViewModel(Car _car)
        {
            Car = _car;
        }
    }
}
