using MoviesRatingSystem.Data;
using MoviesRatingSystem.Model;
using MoviesRatingSystem.Resources;
using Newtonsoft.Json.Linq;
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
        MovieRestApi api;

        private bool serverStatus;
        private DateTime lastReceive;
        private MoviesCollection moviesCollection;
        #endregion Private Fields

        #region Ctor       
        public MainViewModel()
        {
            moviesCollection = new MoviesCollection();
            api = new MovieRestApi();
        }
        #endregion Ctor

        #region Properties     
        public DateTime LastReceive { get => lastReceive; set => SetField(ref lastReceive, value); }
        public bool ServerStatus { get => serverStatus; set => SetField(ref serverStatus  , value); }
        public MoviesCollection MoviesCollection { get => moviesCollection; set => SetField(ref moviesCollection  , value); }
        #endregion Properties

        #region Function
        public void Start()
        {
            ServerStatus = true;
            LastReceive = DateTime.Now.AddSeconds(-1);
            Initialization();
            Routine();
        }

        public void Initialization()
        {
            Task.Run(() =>
            {
                var r1 = api.GetMoviesDescrption().Result;
                JArray array = JArray.Parse(r1);
                MoviesCollection.Initialization(array);
            });          
        }

        public void Routine()
        {
            Task.Run(async () =>
            {             
                do
                {
                    await Task.Delay(1000);
                    var r2 = api.GetOnlineVotes(lastReceive).Result;
                    JArray array = JArray.Parse(r2);
                    if (array.Count > 0)
                        LastReceive = MoviesCollection.UpdateRoutine(array);

                } while (serverStatus) ;
            });
        }
        #endregion Function
    }
}
