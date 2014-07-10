using System;
using Xamarin.Forms;

namespace Sliver.Shared
{
	public class PictureCell: ViewCell
	{
		public PictureCell ()
		{
			// create the layout for the Picture Cell
			var relativeLayout = new RelativeLayout ();

			// create the UI elements in the Picture Cell
			Image pic = new Image
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			Label creatorLabel = new Label 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.White,
				Font = Font.BoldSystemFontOfSize(15)
			};

			Label dateTimeLabel = new Label 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				TextColor = Color.White,
				Font = Font.SystemFontOfSize(15)
			};

			// set property bindings
			pic.SetBinding (Image.SourceProperty, "ImageUrl");
			creatorLabel.SetBinding (Label.TextProperty, "Creator");
			dateTimeLabel.SetBinding (Label.TextProperty, "DateAndTimeString");

		}
	}
}

