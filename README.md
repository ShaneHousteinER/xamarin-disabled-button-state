Complete example for changing text colour on a disabled Xamarin Forms Button.

A custom button class (DisablingButton.cs) is used to provide two properties: EnabledStyle and DisabledStyle.

PropertyChanged is used to check the enabled state, and swap in the associated style (either EnabledStyle or DisabledStyle).

This should have been enough, but unfortunately Xamarin does <em>not allow text color</em> to be changed on a disabled button, so renderers have been added to override the default behaviour. 

Code developed for <a href="https://www.investsmart.com.au">InvestSMART</a>
