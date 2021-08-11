using MoviesRatingSystem.Model;
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
        private bool serverStatus;
        private DateTime lastReceive;
        private MoviesCollection moviesCollection;
        #endregion Private Fields

        #region Ctor       
        public MainViewModel()
        {
            moviesCollection = new MoviesCollection();
        }
        #endregion Ctor

        #region Properties     
        public DateTime LastReceive { get => lastReceive; set => SetField(ref lastReceive, value); }
        public bool ServerStatus { get => serverStatus; set => SetField(ref serverStatus  , value); }
        public MoviesCollection MoviesCollection { get => moviesCollection; set => SetField(ref moviesCollection  , value); }
        #endregion Properties

        #region Function
        #endregion Function
    }
}
