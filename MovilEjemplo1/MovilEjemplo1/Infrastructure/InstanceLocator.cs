﻿
namespace MovilEjemplo1.Infrastructure
{

    using ViewModels;
    public class InstanceLocator
    {
        #region Propiedades
        public MainViewModel Main { get; set; }
        #endregion
        #region Constructor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
