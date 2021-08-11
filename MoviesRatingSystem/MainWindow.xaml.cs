using MoviesRatingSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            //mainViewModel.Start();
        }

        private void SetCollection()
        {
            dataGrid_MoviesCollection.ItemsSource = mainViewModel.MoviesCollection.List;
            //dataGrid_MoviesCollection.AutoGenerateColumns = false;
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

    }
}
