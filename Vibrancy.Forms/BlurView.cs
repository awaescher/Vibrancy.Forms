using Xamarin.Forms;

namespace Vibrancy.Forms
{
	public class BlurView : ContentView
	{
		public static readonly BindableProperty BlurStyleProperty = BindableProperty.Create(
			nameof(BlurStyle),
			typeof(BlurViewStyle),
			typeof(BlurView),
			defaultValue: BlurViewStyle.Regular);

		public static readonly BindableProperty EnableVibrancyProperty = BindableProperty.Create(
			nameof(EnableVibrancy),
			typeof(bool),
			typeof(BlurView),
			defaultValue: false);

		public BlurViewStyle BlurStyle
		{
			get => (BlurViewStyle)GetValue(BlurStyleProperty);
			set => SetValue(BlurStyleProperty, value);
		}

		public bool EnableVibrancy
		{
			get => (bool)GetValue(EnableVibrancyProperty);
			set => SetValue(EnableVibrancyProperty, value);
		}
	}
}
