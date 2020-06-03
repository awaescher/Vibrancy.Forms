using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VibrancyApp
{
	[ContentProperty(nameof(Source))]
	public class ImageResourceExtension : IMarkupExtension
	{
		public object ProvideValue(IServiceProvider serviceProvider)
		{
			if (Source == null)
				return null;

			return ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
		}

		public string Source { get; set; }
	}
}
