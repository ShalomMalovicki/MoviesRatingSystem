using MoviesRatingSystem.Model;
using MoviesRatingSystem.ViewModel;
using MoviesRatingSystem.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace MoviesRatingSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel mainViewModel = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainViewModel;
            SetCollection();
            mainViewModel.Start();
        }

        private void SetCollection()
        {
            dataGrid_MoviesCollection.ItemsSource = mainViewModel.MoviesCollection.MovieList;
            dataGrid_MoviesCollection.AutoGenerateColumns = true;
            dataGrid_MoviesCollection.AutoGeneratingColumn += dataGrid_AutoGeneratingColumn;
            //dataGrid_MoviesCollection.Columns.Add(new GridNumericColumn() { MappingName = "SumAmount", HeaderText = "Bid Total", NumberDecimalDigits = 0, Width = 100, TextAlignment = TextAlignment.Center });
            //dataGrid_MoviesCollection.Columns.Add(new GridNumericColumn() { MappingName = "Amount", HeaderText = "Bid Size", NumberDecimalDigits = 0, Width = 100, TextAlignment = TextAlignment.Center });
            //dataGrid_MoviesCollection.Columns.Add(new GridNumericColumn()
            //{
            //    MappingName = "Price",
            //    HeaderText = "Bid Price",
            //    NumberDecimalDigits = mainViewModel.SettingsViewModel.OrderBookDecimal,
            //    Width = 100
            //    ,
            //    CellStyleSelector = new BidCellStyleSelector(),
            //    TextAlignment = TextAlignment.Center
            //});
        }
        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "IsSelected")
            {
                e.Cancel = true;
            }
        }

        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow row = sender as DataGridRow;
            Movie movie = row.DataContext as Movie;
            //MessageBox.Show($"{movie}");
            Window win = new MovieWindow(movie);
            win.Show();
        }
    }
}
