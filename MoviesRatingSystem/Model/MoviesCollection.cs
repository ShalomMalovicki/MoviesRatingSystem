using MoviesRatingSystem.Resources;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MoviesRatingSystem.Model
{
    public class MoviesCollection : OnePropertyChanged
    {
        #region Private Fields
        private List<Vote> votesList;

        private ObservableCollection<Movie> movieList;
        private int mostVotes;
        #endregion Private Fields

        #region Ctor
        public MoviesCollection() 
        {
            movieList = new ObservableCollection<Movie>();
            votesList = new List<Vote>();
        }
        #endregion Ctor

        #region Properties
        public ObservableCollection<Movie> MovieList { get => movieList; set => SetField(ref movieList , value); }
        public int MostVotes { get => mostVotes; set => SetField(ref mostVotes , value); }
        #endregion Properties

        #region Function
        public void Initialization(JArray array)
        {
            Application.Current.Dispatcher.Invoke(delegate
            {
                foreach (var item in array)
                {
                    // for each token we create & add new Movie instance to the list
                    dynamic token = JObject.Parse(item.ToString());
                    MovieList.Add(new Movie(token));
                }
            });          
        }

        public void UpdateRoutine(JArray array)
        {
            foreach (var item in array)
            {
                // for each token we create & add new Vote instance to the list
                dynamic token = JObject.Parse(item.ToString());
                votesList.Add(new Vote(token));
            }

            foreach (Movie movie in MovieList)
            {
                Vote checkExsit = votesList.Where(x=> x.ItemId == movie.MovieId).FirstOrDefault();
                if (checkExsit != null)
                {
                    //movie.TotalVotes = votesList.Where(x => x.ItemId == movie.MovieId).Select();
                }
            }
        }
        #endregion Function
    }
}
