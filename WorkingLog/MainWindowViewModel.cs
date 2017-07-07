using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingLog
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private LogManager myLogManager = new LogManager();

        public LogManager MyLogManager
        {
            get => myLogManager;
            set
            {
                myLogManager = value;
                OnPropertyChanged(nameof(MyLogManager));
            }
        }

        // nullチェックを省略するためdelegateであらかじめイベントを登録しておく
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
