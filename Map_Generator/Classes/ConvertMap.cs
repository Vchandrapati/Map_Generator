using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Media.Imaging;

namespace Map_Generator.Classes
{
    public class ConvertMap
    {
        public static BitmapImage ConvertToBitmapImage(Bitmap cellMap)
        {
            var ms = new MemoryStream();
            cellMap.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            var map = new BitmapImage();
            map.BeginInit();
            map.StreamSource = ms;
            map.EndInit();
            return map;
        }
    }
}
