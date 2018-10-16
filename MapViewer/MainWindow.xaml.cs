using Esri.ArcGISRuntime.Mapping;
using Esri.ArcGISRuntime.Portal;
using Esri.ArcGISRuntime.Tasks;
using Esri.ArcGISRuntime.Tasks.Offline;
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
            vModel.Label = MapManager.ReadMap(vModel.PathText);
            CreateStyledVectorBasemap2();
        }

        private void CreateStyledVectorBasemap2()
        {
            // Path to the local package (.tpk file).
            string myDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string tileCachePath = System.IO.Path.Combine(myDocumentsFolder, "test.tpk");


            // Create a tile cache from the local data.
            TileCache cache = new TileCache(tileCachePath);


            // Use the tile cache to create an ArcGISTiledLayer.
            ArcGISTiledLayer tiledLayer = new ArcGISTiledLayer(cache);

            // Display the tiled layer as a basemap.
            var map = new Map(new Basemap(tiledLayer));


            double initialLatitude = 35.660859;
            double initialLongitude = 139.795513;
            double initialScale = 300000;
            map.InitialViewpoint = new Viewpoint(initialLatitude, initialLongitude, initialScale);
            vModel.Map = map;

        }
        private void RotationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var slider = sender as System.Windows.Controls.Slider;
            Mapview.SetViewpointRotationAsync(slider.Value * 36);
        }

    }
}
