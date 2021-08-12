using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRatingSystem.Resources
{
    // A generic class to facilitate the use call and implementation of INotifyPropertyChanged
    public class GenericPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Use CallerMemberName instead of calling each property individually
        protected void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            // Check whether the value of the property has changed at all
            if (EqualityComparer<T>.Default.Equals(field, value)) return;
            field = value;
            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged(string name)
        {
            var handle = PropertyChanged;
            if (handle != null)
                handle.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
