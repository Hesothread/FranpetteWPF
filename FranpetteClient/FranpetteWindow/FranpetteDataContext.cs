using System.ComponentModel;
using System.Windows.Controls;

namespace FranpetteClient.FranpetteWindow
{
    public class FranpetteDataContext : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private UserControl _mainWindow;
        public UserControl MainWindow
        {
            get { return _mainWindow; }
            set
            {
                _mainWindow = value;
                OnPropertyChanged("MainWindow");
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}