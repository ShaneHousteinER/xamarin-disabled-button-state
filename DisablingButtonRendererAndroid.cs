using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using InvestSmart.Droid;
using InvestSmart;
using Android.Content;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(DisablingButton), typeof(DisablingButtonRenderer))]
namespace InvestSmart.Droid
{
    public class DisablingButtonRenderer : ButtonRenderer
    {
        public DisablingButtonRenderer(Context context) : base(context) { }

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

            foreach (Setter setter in style.Setters)
            {
                if (setter.Property.PropertyName == "BackgroundColor")
                {
                    Android.Graphics.Color color = ((Color)setter.Value).ToAndroid();
                    Control.SetBackgroundColor(color);
                }
                else if (setter.Property.PropertyName == "TextColor")
                {
                    Android.Graphics.Color color = ((Color)setter.Value).ToAndroid();
                    Control.SetTextColor(color);
                }
            }
        }
    }
}
