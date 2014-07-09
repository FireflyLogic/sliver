using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace sliver
{
	public class PicturesAtPlacePage: ContentPage
	{
		public PicturesAtPlacePage ()
		{
			// set page title
			Title = "City, State";

			// set background of page
			BackgroundColor = Color.Silver;

			/* create UI of page */
			var pictureListView = new ListView ();
			pictureListView.ItemsSource = new List<string> 
			{

			};

			// create refresh control -- IF POSSIBLE WITH XAMARIN FORMS

			/* Handle Events */

			// add padding to the UI -- accomodate the iOS status bar
			Padding = new Thickness (5, Device.OnPlatform (20, 5, 5), 5, 5);

			// set the content of the page

		}
	}
}

