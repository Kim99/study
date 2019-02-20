using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kim.Study.Utils
{
    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageUtil.GetImageSource(this.Source);

            return imageSource;
        }
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value is ImageSource)
            {
                return value;
            }
            return ImageUtil.GetImageSource(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return 0;
            }
            return double.Parse(value.ToString().Replace(",", string.Empty));
        }
    }

    public class ImageUtil
    {
        public static ImageSource GetImageSource(string imgShortName)
        {
            var imageSource = ImageSource.FromResource("Kim.Study.Images." + imgShortName, typeof(ImageResourceExtension).GetTypeInfo().Assembly);

            return imageSource;
        }
    }
}
