
namespace MovilEjemplo1.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using MovilEjemplo1.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        #region Atributos
        public string _Email;
        public string _Password;
        public bool _IsRunning;
        public bool _IsRemember;
        public bool _IsEnabledCommand;
        #endregion
        #region Propiedades
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                SetValue(ref _Email, value);
            }
        }
        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                SetValue(ref _Password, value);
            }
        }
        public bool IsRunning
        {
            get
            {
                return _IsRunning;
            }
            set
            {
                SetValue(ref _IsRunning, value);
            }
        }
        public bool IsRemember
        {
            get
            {
                return _IsRemember;
            }
            set
            {
                _IsRemember = value;
            }
        }
        public bool IsEnabledCommand
        {
            get
            {
                return _IsEnabledCommand;
            }
            set
            {
                SetValue(ref _IsEnabledCommand, value);
            }
        }
        #endregion
        #region Constructor
        public LoginViewModel()
        {
            this.IsRemember = true;
            this.IsEnabledCommand = true;
            this.Email = "alecs";
            this.Password = "123456";
        }
        #endregion
        #region Comandos
        public ICommand IngresarCommand
        {
            get
            {
                return new RelayCommand(Ingresar);
            }
        }

        private async void Ingresar()
        {
            try
            {
                this.IsEnabledCommand = false;
                this.IsRunning = true;

                if (string.IsNullOrEmpty(this.Email))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Email Incorrecto.", "Acceptar");
                    return;
                }
                if (string.IsNullOrEmpty(this.Password))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Password Incorrecto.", "Acceptar");
                    return;
                }

                if (this.Email != "alecs" || this.Password != "123456")
                {
                    this.Password = string.Empty;
                    await Application.Current.MainPage.DisplayAlert("Error", "El Usuario o el Password son Incorrectos.", "Acceptar");
                    return;
                }

                this.Email = string.Empty;
                this.Password = string.Empty;
                MainViewModel.GetInstance().Lands = new LandsViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Acceptar");
            }
            finally
            {
                this.IsEnabledCommand = true;
                this.IsRunning = false;
            }
        }
        #endregion
    }
}
