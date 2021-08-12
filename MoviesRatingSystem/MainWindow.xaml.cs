using MoviesRatingSystem.Model;
using MoviesRatingSystem.ViewModel;
using MoviesRatingSystem.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace MoviesRatingSystem
{
    // Application Main UI
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainViewModel;
            mainViewModel.Start();
        }
       
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Movie movie = row.DataContext as Movie;
            Window win = new MovieWindow(movie);
            win.Show();
        }
    }
}
