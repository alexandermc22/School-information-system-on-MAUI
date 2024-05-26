using CommunityToolkit.Maui.Converters;
using Project.Common.Enum;
using System.Globalization;

namespace Project.App.Converters;

public class GradeToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is GradeScore grade)
        {
            return grade switch
            {
                GradeScore.A => "A",
                GradeScore.B => "B",
                GradeScore.C => "C",
                GradeScore.D => "D",
                GradeScore.E => "E",
                GradeScore.F => "F",
                GradeScore.None => "None",
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
                "A" => GradeScore.A,
                "B" => GradeScore.B,
                "C" => GradeScore.C,
                "D" => GradeScore.D,
                "E" => GradeScore.E,
                "F" => GradeScore.F,
                "None" => GradeScore.None,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        throw new InvalidOperationException("The target must be a string");
    }

}