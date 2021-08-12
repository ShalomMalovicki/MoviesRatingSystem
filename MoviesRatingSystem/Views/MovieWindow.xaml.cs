using MoviesRatingSystem.Model;
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
using System.Windows.Shapes;

namespace MoviesRatingSystem.Views
{
    /// <summary>
    /// Interaction logic for MovieWindow.xaml
    /// </summary>
    public partial class MovieWindow : Window
    {
        public MovieWindow(Movie _movie)
        {
            InitializeComponent();
            DataContext = _movie;
        }
    }
}
