using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapViewer
{
    class MainViewModel : INotifyPropertyChanged
    {
        private string pathText;
        private string label;
        private Esri.ArcGISRuntime.Mapping.Map map;

        public string PathText
        {
            get
            {
                return this.pathText;
            }
            set
            {
                this.pathText = value;
                this.OnPropertyChanged(nameof(pathText));

                return;
            }
        }
        public string Label
        {
            get
            {
                return this.label;
            }
            set
            {
                this.label = value;
                this.OnPropertyChanged(nameof(Label));

                return;
            }
        }
        public Esri.ArcGISRuntime.Mapping.Map Map
        {
            get
            {
                return this.map;
            }
            set
            {
                this.map = value;
                this.OnPropertyChanged(nameof(Map));

                return;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = null;
        protected void OnPropertyChanged(string info)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
    }
}
