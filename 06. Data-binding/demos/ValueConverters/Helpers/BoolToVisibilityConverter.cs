namespace ValueConverters.Helpers
{
    using System;
    using System.Linq;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Data;

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (targetType != typeof(Visibility))
            {
                return null;
            }
            bool boolVal;
            if (!bool.TryParse(value.ToString(), out boolVal))
            {
                return null;
            }

            return boolVal ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
