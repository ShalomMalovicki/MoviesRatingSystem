using MoviesRatingSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.ViewModel
{
    class MainViewModel : OnePropertyChanged
    {
        #region Private Fields
        private DateTime lastReceive;
        #endregion Private Fields

        #region Ctor       
        public MainViewModel()
        {
        }
        #endregion Ctor

        #region Properties
        public DateTime LastReceive { get => lastReceive; set => SetField(ref lastReceive, value); }

        #endregion Properties

        #region Function
        #endregion Function
    }
}
