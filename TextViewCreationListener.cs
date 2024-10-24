using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Utilities;
using SpookyVS.Effects;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Media;

namespace SpookyVS;

[Export(typeof(IWpfTextViewCreationListener))]
[ContentType("text")]
[TextViewRole(PredefinedTextViewRoles.Document)]
internal class TextViewCreationListener : IWpfTextViewCreationListener
{
    public void TextViewCreated(IWpfTextView textView)
    {
        var elementView = textView as UIElement;
        if (elementView != null)
        {
            elementView.IsVisibleChanged += (s, ea) =>
            {
                var parent = VisualTreeHelper.GetParent(elementView) as UIElement;
                if (parent == null)
                    return;

                if (parent.Effect == null)
                {                    
                    var effect = new FlashlightEffect();

                    parent.MouseMove += (s, ea) =>
                    {
                        var pos = ea.GetPosition(parent);
                        var size = parent.RenderSize;
                        effect.LightPosition = new Point(pos.X / size.Width, pos.Y / size.Height);
                    };
                    parent.Effect = effect;
                }
            };
        }
    }

}
