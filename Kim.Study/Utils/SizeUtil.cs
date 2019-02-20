using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Xamarin.Essentials;

namespace Kim.Study.Utils
{
    [ContentProperty(nameof(Size))]
    class SizeCalcExtension : IMarkupExtension
    {
        public double Size { get; set; }
        public bool Dual { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return SizeUtil.GetSize(this.Size, this.Dual);
        }
    }

    public class SizeUtil
    {
        public static double GetSize(double _size, bool dual = false)
        {
            if (_size == 0)
            {
                return 0;
            }
            //var metrics = DeviceDisplay.ScreenMetrics;

            //// Orientation (Landscape, Portrait, Square, Unknown)
            //var orientation = metrics.Orientation;

            //// Rotation (0, 90, 180, 270)
            //var rotation = metrics.Rotation;

            //// Width (in pixels)
            //var width = metrics.Width;

            //// Height (in pixels)
            //var height = metrics.Height;

            //// Screen density
            //var density = metrics.Density;
            double size = _size / 750 * DeviceDisplay.MainDisplayInfo.Width; //DeviceDisplay.KeepScreenOn;
            //if (dual && DeviceInfo.Platform == Device.Android && DeviceInfo.Idiom == TargetIdiom.Phone.ToString())
            //{
            //    size *= 2;
            //}
            return size;
        }
    }
}
