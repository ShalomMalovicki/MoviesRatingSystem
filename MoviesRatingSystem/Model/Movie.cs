using MoviesRatingSystem.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Model
{
    public class Movie : OnePropertyChanged
    {
        private long movieId;
        private string movieDescription;
        private int totalVotes;
        private DateTime lastUpdated;

        public long MovieId { get => movieId; set => SetField(ref movieId , value); }
        public string MovieDescription { get => movieDescription; set => SetField(ref movieDescription , value); }
        public int TotalVotes { get => totalVotes; set => SetField(ref totalVotes, value); }
        public DateTime LastUpdated { get => lastUpdated; set => SetField(ref lastUpdated , value); }
    }
}
