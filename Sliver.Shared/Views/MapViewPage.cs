using System;
using Xamarin.Forms;

namespace Sliver.Shared
{
	public class MapViewPage : ContentPage
	{
		public MapViewPage ()
		{
			Title = "Map View";
			BackgroundColor = Color.Teal;

			var random = new Label 
			{
				Text = "This will be the map view page",
				TextColor = Color.White,
				Font = Font.BoldSystemFontOfSize(18),
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
					
			Content = new StackLayout 
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Children = 
				{
					random
				}
			};
		}
	}
}

