using System;
using Esri.ArcGISRuntime.Mapping;

namespace MapViewer
{
    class MapManager
    {
        static public Map ReadMap(string path)
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


            return map;
        }
    }
}
