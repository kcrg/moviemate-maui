namespace MovieMate.Maui.Controls;

public class BaseToolbarItem : ToolbarItem
{
    private readonly FontImageSource fontImageSource = new();

    public BaseToolbarItem()
    {
        fontImageSource.FontFamily = "IconFont";
        fontImageSource.Size = 20;
        IconImageSource = fontImageSource;
    }

    public static readonly BindableProperty GlyphProperty = BindableProperty.Create(nameof(Glyph), typeof(string), typeof(BaseToolbarItem), default(string), BindingMode.OneTime);
    public string Glyph
    {
        get => (string)GetValue(GlyphProperty);
        set => SetValue(GlyphProperty, value);
    }

    public static readonly BindableProperty GlyphColorProperty = BindableProperty.Create(nameof(GlyphColor), typeof(Color), typeof(BaseToolbarItem), default(Color), BindingMode.OneTime);
    public Color GlyphColor
    {
        get => (Color)GetValue(GlyphColorProperty);
        set => SetValue(GlyphColorProperty, value);
    }

    protected override void OnPropertyChanged(string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == GlyphProperty.PropertyName)
        {
            fontImageSource.Glyph = Glyph;
        }
        if (propertyName == GlyphColorProperty.PropertyName)
        {
            fontImageSource.Color = GlyphColor;
        }
    }
}