using System.Windows.Media.Effects;
using System.Windows;
using System.Windows.Media;

namespace SpookyVS.Effects;

class FlashlightEffect : ShaderEffect
{
    public static readonly DependencyProperty InputProperty =
        RegisterPixelShaderSamplerProperty(nameof(Input), typeof(FlashlightEffect), 0);

    public static readonly DependencyProperty LightPositionProperty =
        DependencyProperty.Register(nameof(LightPosition), typeof(Point), typeof(FlashlightEffect),
            new UIPropertyMetadata(new Point(0.0, 0.0), PixelShaderConstantCallback(0)));

    public Brush Input
    {
        get
        {
            return (Brush)GetValue(InputProperty);
        }
        set
        {
            SetValue(InputProperty, value);
        }
    }

    public Point LightPosition
    {
        get
        {
            return (Point)GetValue(LightPositionProperty);
        }
        set
        {
            SetValue(LightPositionProperty, value);
        }
    }

    public FlashlightEffect()
    {
        PixelShader = new PixelShader() { UriSource = MakePackUri("Flashlight.ps") };
        UpdateShaderValue(InputProperty);
        UpdateShaderValue(LightPositionProperty);
    }

    public static Uri MakePackUri(string relativeFile)
    {
        return new Uri($"pack://application:,,,/{typeof(FlashlightEffect).Assembly.GetName().Name};component/Shaders/{relativeFile}", UriKind.Absolute);
    }
}
