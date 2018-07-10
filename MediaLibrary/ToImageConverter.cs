using MediaLibraryDataAccess;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace MediaLibrary
{
    [ValueConversion(typeof(string), typeof(bool))]
    public class ToImageConverter : IValueConverter
    {
        public static ToImageConverter Instance =
            new ToImageConverter();

        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            Uri uri;
            if ((value as string).Contains(@"\"))
            {
                uri = new Uri("pack://application:,,,/Resources/Images/drive.png");
            }
            else
            {
                switch (value as string)
                {
                    case FileTypesConstants.Audio:
                        uri = new Uri("pack://application:,,,/Resources/Images/music.png");
                        break;
                    case FileTypesConstants.Video:
                        uri = new Uri("pack://application:,,,/Resources/Images/video.png");
                        break;
                    case FileTypesConstants.Image:
                        uri = new Uri("pack://application:,,,/Resources/Images/image.png");
                        break;
                    case FileTypesConstants.Other:
                        uri = new Uri("pack://application:,,,/Resources/Images/file.png");
                        break;
                    default:uri = new Uri("pack://application:,,,/Resources/Images/folder.png");
                        break;
                }                                
            }
            BitmapImage source = new BitmapImage(uri);
            return source;
        }
        
        public object ConvertBack(object value, Type targetType,
                object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }  
}
