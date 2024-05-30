using CommunityToolkit.Maui.Converters;
using Project.Common.Enum;
using System.Globalization;

namespace Project.App.Converters;

public class GradeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Grade grade)
        {
            return grade switch
            {
                Grade.A => "A",
                Grade.B => "B",
                Grade.C => "C",
                Grade.D => "D",
                Grade.E => "E",
                Grade.F => "F",
                Grade.None => "None",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        throw new InvalidOperationException("The target must be a Grade enum");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str)
        {
            return str switch
            {
                "A" => Grade.A,
                "B" => Grade.B,
                "C" => Grade.C,
                "D" => Grade.D,
                "E" => Grade.E,
                "F" => Grade.F,
                "None" => Grade.None,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        throw new InvalidOperationException("The target must be a string");
    }

}