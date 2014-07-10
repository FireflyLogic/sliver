using System;
using Xamarin.Forms;
using Sliver.Shared;


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

			// set the view model
			var viewModel = new PictureViewModel ();

			/* create UI of page */
			// create the list view
			var pictureListView = new ListView 
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			pictureListView.ItemsSource = viewModel.pictureList;

			// create and customize the cell(s)
			var cell = new DataTemplate (typeof(PictureCell));
			pictureListView.ItemTemplate = cell;

			// create refresh control -- IF POSSIBLE WITH XAMARIN FORMS

			/* Handle Events */
			pictureListView.ItemTapped += (object sender, ItemTappedEventArgs e) => 
			{
				Console.WriteLine("--> picture tapped!");
			};

			// add padding to the UI -- accomodate the iOS status bar
			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			// set the content of the page
			this.Content = new StackLayout 
			{
				Children = { pictureListView }
			};
		}
	}
}

