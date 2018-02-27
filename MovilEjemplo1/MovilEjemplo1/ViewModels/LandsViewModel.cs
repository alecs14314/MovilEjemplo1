
namespace MovilEjemplo1.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using MovilEjemplo1.Models;
    using Services;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Servicios
        ApiService apiService;
        #endregion
        #region Atributos
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefreshing;
        private string filtro;
        private List<Land> landList;
        #endregion

        #region Propiedades
        public ObservableCollection<LandItemViewModel> Lands
        {
            get
            {
                return lands;
            }
            set
            {
                SetValue(ref lands, value);
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                SetValue(ref isRefreshing, value);
            }
        }
        public string Filtro
        {
            get
            {
                return filtro;
            }
            set
            {
                SetValue(ref filtro, value);
                Search();
            }
        }
        #endregion
        #region Contructores
        public LandsViewModel()
        {
            apiService = new ApiService();
            LoadLands();
        }
        #endregion

        #region Metodos
        async void LoadLands()
        {
            IsRefreshing = true;
            Response respuesta = await apiService.GetList<Land>("https://restcountries.eu", "/rest", "/v2/all");

            if (!respuesta.IsSuccess)
            {
                IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", respuesta.Message, "Aceptar");
                return;
            }
            this.landList = (List<Land>)respuesta.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            IsRefreshing = false;
        }
        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filtro))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(this.ToLandItemViewModel().Where(l => l.Name.ToLower().Contains(this.Filtro.ToLower()) || l.Capital.ToLower().Contains(this.Filtro.ToLower())));
            }
        }
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return this.landList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            }).ToList();
        }
        #endregion
        #region Comandos
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }
        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        } 
        #endregion
    }
}
