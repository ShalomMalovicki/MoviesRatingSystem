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
    // For maintaining the list of movie voting data
    public class MoviesCollection : GenericPropertyChanged
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

        public DateTime UpdateRoutine(JArray array)
        {
            // Used as temporary storage of voting data for segmenting and arranging voting data below
            foreach (var item in array)
            {
                // for each token we create & add new Vote instance to the list
                dynamic token = JObject.Parse(item.ToString());
                votesList.Add(new Vote(token));
            }

            // Extracting any specific data for each film separately
            foreach (Movie movie in MovieList)
            {
                Vote checkExsit = votesList.Where(x=> x.ItemId == movie.MovieId).FirstOrDefault();
                if (checkExsit != null)
                {
                    movie.TotalVotes = votesList.Where(x => x.ItemId == movie.MovieId).Sum(item => item.ItemCount);
                    movie.LastUpdated = votesList.Where(x => x.ItemId == movie.MovieId).Max(item => item.GeneratedTime);
                }
            }

            // Receiving the highest number of votes and marking the above film
            MostVotes = movieList.Max(item => item.TotalVotes);
            foreach (Movie movie in MovieList)
            {
                if (movie.TotalVotes == MostVotes)
                    movie.IsSelected = true;
                else
                    movie.IsSelected = false;
            }

            // For the next update round we will get the latest update date as the requirements
            return movieList.Max(item => item.LastUpdated);
        }
        #endregion Function
    }
}
