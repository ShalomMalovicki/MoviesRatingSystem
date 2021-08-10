using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Resources
{
    public class OnePropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            OnPropertyChanged1(propertyName);
        }

        protected void OnPropertyChanged1(string name)
        {
            var handle = PropertyChanged;
            if (handle != null)
                handle.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // : OnePropertyChanged
    // { get; set; }//{ get => ; set => SetField(ref , value); 
}
