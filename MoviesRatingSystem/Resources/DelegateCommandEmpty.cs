using System;
using System.Windows.Input;

namespace MoviesRatingSystem.Resources
{
    public class DelegateCommandEmpty : ICommand
    {
        private Action _method;
       
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="method">The method.</param>
        public DelegateCommandEmpty(Action method)
        {
            _method = method;
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {          
            return true;
        }

       
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter = null)
        {
            if (_method != null)
                _method.Invoke();
        }

        #region ICommand Members

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
