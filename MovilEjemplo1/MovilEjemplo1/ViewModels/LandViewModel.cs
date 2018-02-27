
namespace MovilEjemplo1.ViewModels
{
    using System;
    using MovilEjemplo1.Models;

    public class LandViewModel
    {
        #region Propiedades
        public Land Land { get; set; }
        #endregion
        #region Constructor
        public LandViewModel(Land land)
        {
            Land = land;
        }
        #endregion
    }
}
