using Catalogo_de_Carros.Models;
using Catalogo_de_Carros.Services;
using Catalogo_de_Carros.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Catalogo_de_Carros.ViewModels
{
    public partial class CatalogoViewModel : BaseViewModel
    {
        #region Properties
        private RestService _restService;

        [ObservableProperty]
        private ObservableCollection<Car> _listCars = new();
        private List<Car> _listAllCars = new();

        [ObservableProperty]
        private bool _filterTypesVisible;
        [ObservableProperty]
        private bool _filterForYear;
        [ObservableProperty]
        private bool _filterForModel;
        [ObservableProperty]
        private bool _clearButtonFilterVisible;

        [ObservableProperty]
        private string _entryFilterYear;
        [ObservableProperty]
        private string _entryFilterModel;

        #endregion

        #region Commands
        [RelayCommand]
        private async Task OnDetalheCarro(Car car) 
        {
            await Shell.Current.Navigation.PushAsync(new DetalheCarroPage(car));
        }

        [RelayCommand]
        private async Task OnAtiveFilters(string type)
        {
            try
            {
                switch (type)
                {
                    case "1":
                        FilterForYear = true; 
                        FilterForModel = false;
                        ClearButtonFilterVisible = true;
                        EntryFilterYear = null;
                        EntryFilterModel = null;
                        break;
                    case "2":
                        FilterForModel = true;
                        FilterForYear = false;
                        ClearButtonFilterVisible = true;
                        EntryFilterModel = null;
                        EntryFilterYear = null;
                        break;
                    default:
                        FilterTypesVisible = !FilterTypesVisible;
                        EntryFilterModel = null;
                        EntryFilterYear = null;
                        break;
                }
                
            }
            catch (global::System.Exception)
            {
                throw;
            }
        }

        [RelayCommand]
        private async Task OnSearchForYear()
        {
            try
            {
                await ShowLoading();

                if (EntryFilterYear != null)
                {
                    var filterList = _listAllCars.Where(c => c.Year.ToString().Contains(EntryFilterYear)).ToList();
                    ListCars = new ObservableCollection<Car>(filterList);
                    FilterTypesVisible = false;
                }
            }
            catch (global::System.Exception)
            {
                throw;
            }
            finally
            {
                await HideLoading();
            }
        }

        [RelayCommand]
        private async Task OnSearchForModel()
        {
            try
            {
                await ShowLoading();

                if (EntryFilterModel != null)
                {
                    var filterList = _listAllCars.Where(c => c.Model.Contains(EntryFilterModel)).ToList();
                    ListCars = new ObservableCollection<Car>(filterList);
                    FilterTypesVisible = false;
                }
            }
            catch (global::System.Exception)
            {
                throw;
            }
            finally
            {
                await HideLoading();
            }
        }

        [RelayCommand]
        private async Task OnSearchForFavorites()
        {
            try
            {
                await ShowLoading();

                var filterList = _listAllCars.Where(c => c.Favorite).ToList();
                ListCars = new ObservableCollection<Car>(filterList);
                FilterTypesVisible = false;
                ClearButtonFilterVisible = true;
            }
            catch (global::System.Exception)
            {
                throw;
            }
            finally
            {
                await HideLoading();
            }
        }

        [RelayCommand]
        private async Task OnCLearFilter()
        {
            try
            {
                await ShowLoading();

                ListCars = new ObservableCollection<Car>(_listAllCars);
                ClearButtonFilterVisible = false;
                EntryFilterYear = null;
                EntryFilterModel = null;
            }
            catch (global::System.Exception)
            {
                throw;
            }
            finally
            {
                await HideLoading();
            }
        }

        [RelayCommand]
        private async Task OnFavorateCar(Car car)
        {
            try
            {
                await ShowLoading();

                if (car.Favorite)
                    _listAllCars.FirstOrDefault(c => c.Id == car.Id).Favorite = false;
                else
                    _listAllCars.FirstOrDefault(c => c.Id == car.Id).Favorite = true;

                ListCars = new ObservableCollection<Car>(_listAllCars);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                await HideLoading();
            }
        }
        #endregion

        public CatalogoViewModel()
        {
            _restService = new RestService();
        }

        public async Task LoadData()
        {
            try
            {
                await ShowLoading();

                if (ListCars.Count == 0)
                {
                    _listAllCars = new(await _restService.GetCarrosPelaMarca("volkswagen"));
                    for (int i = 0; i <= _listAllCars.Count() - 1; i++)
                    {
                        _listAllCars[i].Image = "https://img.olx.com.br/thumbs256x256/86/862379559879490.jpg";
                        _listAllCars[i].Id = i;
                    } 

                    ListCars = new(_listAllCars);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                await HideLoading();
            }
        }
    }
}
