
using MoviesRatingSystem.ViewModel;
using System.Windows;
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
            mainViewModel.Row_DoubleClick(sender);
        }
    }
}
