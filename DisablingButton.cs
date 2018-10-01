using System;
using Xamarin.Forms;

namespace InvestSmart
{
    /// <summary>
    /// Xamarin.Forms Button that allows for applying a different style when enabled.
    /// </summary>
    public class DisablingButton : Button
    {
        public static readonly BindableProperty DisabledStyleProperty =
            BindableProperty.Create(nameof(DisabledStyle), typeof(Style), typeof(DisablingButton), null, BindingMode.TwoWay, null, (obj, oldValue, newValue) => { });
        
        public static readonly BindableProperty EnabledStyleProperty =
            BindableProperty.Create(nameof(EnabledStyle), typeof(Style), typeof(DisablingButton), null, BindingMode.TwoWay, null, (obj, oldValue, newValue) => { });
        
        public Style EnabledStyle
        {
            get { return (Style)GetValue(EnabledStyleProperty); }
            set { SetValue(EnabledStyleProperty, value); }
        }

        public Style DisabledStyle
        {
            get { return (Style)GetValue(DisabledStyleProperty); }
            set { SetValue(DisabledStyleProperty, value); }
        }

        public DisablingButton() : base()
        {
            PropertyChanged += ExtendedButton_PropertyChanged;
        }

        private void ExtendedButton_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(IsEnabled) && DisabledStyle != null)
            {
                if (IsEnabled)
                    Style = EnabledStyle;
                else
                    Style = DisabledStyle;
            }
        }
    }
}