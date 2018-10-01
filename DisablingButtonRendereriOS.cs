using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using InvestSmart.iOS;
using InvestSmart;
using UIKit;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(DisablingButton), typeof(DisablingButtonRenderer))]
namespace InvestSmart.iOS
{
    public class DisablingButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> args)
        {
            base.OnElementChanged(args);
            if (Control != null) SetColors();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);
            if (args.PropertyName == nameof(Button.IsEnabled)) SetColors();
        }

        private void SetColors()
        {
            Style style;
            if (Element == null) return;

            if (Element.IsEnabled)
            {
                style = (Element as DisablingButton).EnabledStyle;
            }
            else
            {
                style = (Element as DisablingButton).DisabledStyle; 
            }

            foreach(Setter setter in style.Setters)
            {
                if (setter.Property.PropertyName == "BackgroundColor")
                {
                    UIColor color = ((Color)setter.Value).ToUIColor();
                    Control.BackgroundColor = color;
                }
                else if (setter.Property.PropertyName == "TextColor")
                {
                    UIColor color = ((Color)setter.Value).ToUIColor();
                    Control.SetTitleColor(color, Element.IsEnabled ? UIControlState.Normal : UIControlState.Disabled);
                }
            }
        }
    }
}