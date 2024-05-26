using CommunityToolkit.Maui.Converters;
using Project.BL.Models;
using System.Globalization;

namespace Project.App.Converters;
//
public class ModelIsNewToIsVisibleConverter : BaseConverterOneWay<ModelBase, bool>
{
    public override bool ConvertFrom(ModelBase value, CultureInfo? culture)
        => value.Id == Guid.Empty;
    
    public override bool DefaultConvertReturnValue { get; set; } = true;
}