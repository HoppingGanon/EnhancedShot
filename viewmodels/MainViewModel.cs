using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnhancedShot
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string fileName;
        public string FileName
        {
            get { return fileName; }
            set { 
                fileName = value;

                MessageBox.Show(value);
            }
        }

        public MainViewModel()
        {

        }


        //UIに自動更新を行うためのイベント
        protected virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
