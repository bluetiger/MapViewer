using Esri.ArcGISRuntime.Mapping;
using System;
using System.Windows;

namespace MapViewer
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vModel;

        public MainWindow()
        {
            InitializeComponent();
            vModel = new MainViewModel();
            this.DataContext = vModel;
            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void ButtonMapRead(object sender, RoutedEventArgs e)
        {
            string myDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            vModel.Map = MapManager.ReadMap(System.IO.Path.Combine(myDocumentsFolder, "test.tpk"));
            double initialLatitude = 35.660859;
            double initialLongitude = 139.795513;
            double initialScale = 300000;
            vModel.Map.InitialViewpoint = new Viewpoint(initialLatitude, initialLongitude, initialScale);
        }

        private void RotationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as System.Windows.Controls.Slider;
            Mapview.SetViewpointRotationAsync(slider.Value * 36);
        }

    }
}
