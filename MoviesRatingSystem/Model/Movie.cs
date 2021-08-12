using MoviesRatingSystem.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Model
{
    public class Movie : OnePropertyChanged
    {
        #region Private Fields
        private long movieId;
        private string movieDescription;
        private int totalVotes;
        private DateTime lastUpdated;
        private bool isSelected;
        #endregion Private Fields

        #region Ctor
        public Movie() { }
        public Movie(dynamic token) 
        {
            MovieId = token.id;
            MovieDescription = token.description;
        }
        #endregion Ctor

        #region Properties
        public long MovieId { get => movieId; set => SetField(ref movieId, value); }
        public string MovieDescription { get => movieDescription; set => SetField(ref movieDescription, value); }
        public int TotalVotes { get => totalVotes; set => SetField(ref totalVotes, value); }
        public DateTime LastUpdated { get => lastUpdated; set => SetField(ref lastUpdated, value); }
        [Display(AutoGenerateField = false)]
        public bool IsSelected { get => isSelected; set => SetField(ref isSelected , value); }       
        #endregion Properties

        #region Function
        public override string ToString()
        {
            return $"MovieId: {MovieId},\tMovieDescription: {MovieDescription},\tTotalVotes: {TotalVotes},\tLastUpdated: {LastUpdated}";
        }
        #endregion Function
    }
}
