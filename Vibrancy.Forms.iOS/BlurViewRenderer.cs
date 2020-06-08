using System.ComponentModel;
using System.Linq;
using CoreGraphics;
using UIKit;
using Vibrancy.Forms;
using Vibrancy.Forms.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BlurView), typeof(BlurViewRenderer))]
namespace Vibrancy.Forms.iOS.Renderers
{
	public class BlurViewRenderer : VisualElementRenderer<BlurView>
	{
		private UIVisualEffectView _blurView;
		private UIVisualEffectView _vibrancyView;

		protected override void OnElementChanged(ElementChangedEventArgs<BlurView> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement is BlurView)
				CreateEffects();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(BlurView.BlurStyle):
					UpdateBlurEffect();
					UpdateVibrancyEffect();
					break;

				case nameof(BlurView.EnableVibrancy):
					UpdateVibrancyEffect();
					break;
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			if (Bounds.Width > 0)
				LayoutEffects();
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);

			if (disposing)
			{
				_blurView?.RemoveFromSuperview();
				_blurView?.Dispose();
				_blurView = null;

				_vibrancyView?.RemoveFromSuperview();
				_vibrancyView?.Dispose();
				_vibrancyView = null;
			}
		}

		private void CreateEffects()
		{
			if (_blurView == null)
			{
				_blurView = new UIVisualEffectView() { ClipsToBounds = true, BackgroundColor = UIColor.Clear };
				_blurView.TranslatesAutoresizingMaskIntoConstraints = false;

				_vibrancyView = new UIVisualEffectView();
				_vibrancyView.TranslatesAutoresizingMaskIntoConstraints = false;

				_vibrancyView.ContentView.Add(this.Subviews.Single());
				_blurView.ContentView.Add(_vibrancyView);

				InsertSubview(_blurView, 0);
			}

			UpdateBlurEffect();
			UpdateVibrancyEffect();
			LayoutEffects();
		}

		private void UpdateBlurEffect()
		{
			if (_blurView != null)
				_blurView.Effect = UIBlurEffect.FromStyle(ConvertBlurStyle());
		}

		private void UpdateVibrancyEffect()
		{
			if (_vibrancyView != null)
				_vibrancyView.Effect = GetVibrancyEffect();
		}

		private UIVibrancyEffect GetVibrancyEffect()
		{
			if (Element.EnableVibrancy)
				return UIVibrancyEffect.FromBlurEffect((UIBlurEffect)_blurView.Effect);

			return null;
		}

		private void LayoutEffects()
		{
			if (_blurView != null)
				_blurView.Frame = new CGRect(0, 0, Bounds.Width, Bounds.Height);

			if (_vibrancyView != null)
				_vibrancyView.Frame = new CGRect(0, 0, Bounds.Width, Bounds.Height);
		}

		private UIBlurEffectStyle ConvertBlurStyle()
		{
			switch (Element.BlurStyle)
			{
				case BlurViewStyle.Light:
					return UIBlurEffectStyle.Light;
				case BlurViewStyle.ExtraLight:
					return UIBlurEffectStyle.ExtraLight;
				case BlurViewStyle.Dark:
					return UIBlurEffectStyle.Dark;
				case BlurViewStyle.ExtraDark:
					return UIBlurEffectStyle.ExtraDark;
				case BlurViewStyle.Prominent:
					return UIBlurEffectStyle.Prominent;

				default:
					return UIBlurEffectStyle.Regular;
			}
		}
	}
}
