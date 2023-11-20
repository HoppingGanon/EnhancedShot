using EnhancedShot.viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.Threading;

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
            this.loadJson("settings.json");
            this.listening = true;
        }

        public bool close()
        {
            return this.saveJson("settings.json");
        }

        public string previewImage = "/resource/noimage.png";
        public string PreviewImage
        {
            get { return this.previewImage; }
            set {  this.previewImage = value; }
        }

        public int previewSlider = 0;
        public int PreviewSlider
        {
            get { return this.previewSlider; }
            set { this.previewSlider = value; }
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
