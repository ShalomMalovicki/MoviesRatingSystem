using MoviesRatingSystem.Data;
using MoviesRatingSystem.Model;
using MoviesRatingSystem.Resources;
using MoviesRatingSystem.Views;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoviesRatingSystem.ViewModel
{
    // use in MVVM pattern to implementation all functionality individually from view
    class MainViewModel : GenericPropertyChanged
    {
        #region Private Fields
        MovieRestApi api;

        private bool serverStatus;
        private DateTime lastReceive;
        private MoviesCollection moviesCollection;
        private ICommand serverStatusCommand;
        #endregion Private Fields

        #region Ctor       
        public MainViewModel()
        {
            moviesCollection = new MoviesCollection();
            api = new MovieRestApi();
            serverStatusCommand = new DelegateCommandEmpty(ServerStatusCommandExecute);
        }
        #endregion Ctor

        #region Properties     
        public DateTime LastReceive { get => lastReceive; set => SetField(ref lastReceive, value); }
        public bool ServerStatus { get => serverStatus; set => SetField(ref serverStatus  , value); }
        public MoviesCollection MoviesCollection { get => moviesCollection; set => SetField(ref moviesCollection  , value); }
        public ICommand ServerStatusCommand { get => serverStatusCommand; set => serverStatusCommand = value; }

        #endregion Properties

        #region Function
        public void Start()
        {
            ServerStatus = true;
            LastReceive = ConvertFunc.ConvertToFullDateTimeWithSeconds("06/01/2021 09:57:51");
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
                        LastReceive = MoviesCollection.UpdateRoutine(array);  // For the next update round we will return the latest update date as the requirements

                } while (serverStatus) ;
            });
        }

        // MVVM pattern
        public void ServerStatusCommandExecute()
        {
            if (ServerStatus)
            {
                ServerStatus = false;
            }
            else
            {
                ServerStatus = true;
                Routine();
            }
        }

        // MVVM pattern
        public void Row_DoubleClick(object sender)
        {
            DataGridRow row = sender as DataGridRow;
            Movie movie = row.DataContext as Movie;
            Window win = new MovieWindow(movie);
            win.Show();
        }
        #endregion Function
    }
}
