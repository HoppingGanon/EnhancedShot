using EnhancedShot.viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnhancedShot
{
    internal class MainViewModel : FlatSettings, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public string fileName;
        public string FileName
        {
            get { return fileName; }
            set { 
                fileName = value;
            }
        }

        public string subFolderLabel = "サブフォルダ名";

        public string nameLabel = "ファイル名";
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
