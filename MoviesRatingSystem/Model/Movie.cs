using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Model
{
    public class Movie
    {
        private long movieId;
        private string movieDescription;
        private int totalVotes;
        private DateTime lastUpdated;

        public long MovieId { get => movieId; set => movieId = value; }
        public string MovieDescription { get => movieDescription; set => movieDescription = value; }
        public int TotalVotes { get => totalVotes; set => totalVotes = value; }
        public DateTime LastUpdated { get => lastUpdated; set => lastUpdated = value; }
    }
}
