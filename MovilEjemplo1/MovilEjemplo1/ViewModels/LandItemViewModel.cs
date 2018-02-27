

namespace MovilEjemplo1.ViewModels
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using MovilEjemplo1.Models;
    using MovilEjemplo1.Views;
    using Xamarin.Forms;

    public class LandItemViewModel : Land
    {
        #region Metodos 

        private async void SeleccionarLand()
        {
            MainViewModel.GetInstance().Land = new LandViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new LandPage());

        }
        #endregion
        #region Comandos

        public ICommand SeleccionarLandCommand
        {
            get
            {
                return new RelayCommand(SeleccionarLand);
            }
        }
        #endregion

    }
}
