using CommunityToolkit.Maui.Converters;
// using Project.App.Resources.Texts;
using System.Globalization;
using Project.App.Resources.Text;
using Project.Common.Enum;

namespace Project.App.Converters;


public class FoodTypeToStringConverter : BaseConverterOneWay<WeekDay, string>
{
    public override string ConvertFrom(WeekDay value, CultureInfo? culture)
        => DayOfWeekTexts.ResourceManager.GetString(value.ToString(), culture)
           ?? DayOfWeekTexts.None;

    public override string DefaultConvertReturnValue { get; set; } = DayOfWeekTexts.None;
}