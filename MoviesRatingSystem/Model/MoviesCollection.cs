using MoviesRatingSystem.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Model
{
    public class MoviesCollection : OnePropertyChanged
    {
        #region Private Fields
        private ObservableCollection<Movie> list;
        private int mostVotes;
        #endregion Private Fields

        #region Ctor
        public MoviesCollection() 
        {
            list = new ObservableCollection<Movie>();
        }
        #endregion Ctor

        #region Properties
        public ObservableCollection<Movie> List { get => list; set => SetField(ref list , value); }
        public int MostVotes { get => mostVotes; set => SetField(ref mostVotes , value); }
        #endregion Properties

        #region Function
        public void Initialization(JArray array)
        {
            foreach (dynamic item in array)
            {
              
            }
        }

        public void UpdateRoutine(JArray array)
        {
            foreach (dynamic item in array)
            {
              
            }
        }
        #endregion Function
    }
}
