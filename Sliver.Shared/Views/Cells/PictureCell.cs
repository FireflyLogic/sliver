using System;
using Xamarin.Forms;
using sliver;

namespace Sliver.Shared
{
	public class PictureCell : ViewCell
	{
		public PictureCell ()
		{
			// create the layout for the Picture Cell
			var relativeLayout = new RelativeLayout ();

			/* create the UI elements in the Picture Cell */
			// create picture 
			var pic = new Image
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			// create creator label 
			var creatorLabel = new Label 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				TextColor = Color.White,
				Font = Font.BoldSystemFontOfSize(15),
			};

			// create date and time label
			var dateTimeLabel = new Label 
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				TextColor = Color.White,
				Font = Font.SystemFontOfSize(15),
			};

			pic.SetBinding (Image.SourceProperty, "ImageUrl");
			creatorLabel.SetBinding (Label.TextProperty, "Creator");
			dateTimeLabel.SetBinding (Label.TextProperty, "DateAndTimeString");

			/* - * end UI elements in Picture Cell * - */

			// add children to relativeLayout
			relativeLayout.Children.Add ((Image)pic, 
				null, 
				null, 
				Constraint.RelativeToParent ((parent) => 
					{
						return parent.Width;
					}), 
				Constraint.RelativeToParent ((parent) => 
					{
						return parent.Height;
					})
			);

			var stackLayout = new StackLayout 
			{
				BackgroundColor = Color.FromRgba(255, 255, 255, 50),
				Orientation = StackOrientation.Horizontal,
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 100,
				Children = 
				{
					(Label)creatorLabel,
					(Label)dateTimeLabel
				}
			};

			relativeLayout.Children.Add (stackLayout, 
				null, 
				Constraint.RelativeToView ((Image)pic, (parent, sibling) => 
					{
						return sibling.Height - 100;
					}), 
				Constraint.RelativeToParent ((parent) => 
					{
						return parent.Width;
					}), 
				null
			);

			this.View = relativeLayout;
		}
	}
}

