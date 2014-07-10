﻿using System;
using Xamarin.Forms;
using Sliver.Shared;


namespace sliver
{
	public class PicturesAtPlacePage : ContentPage
	{
		private PictureViewModel ViewModel
		{
			get{ return BindingContext as PictureViewModel; }
		}

		public PicturesAtPlacePage ()
		{
			// set page title
			Title = "Nashville, TN";

			// set background of page
			BackgroundColor = Color.Silver;

			// set the view model
			BindingContext = new PictureViewModel ();

			/* create UI of page */
			// create the list view
			var pictureListView = new ListView 
			{
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				RowHeight = 250,
				InputTransparent = false
			};
			pictureListView.ItemsSource = ViewModel.pictureList;
					
			// create and customize the cell(s)
			var cell = new DataTemplate (typeof(PictureCell));
			pictureListView.ItemTemplate = cell;
		
			// create refresh control -- IF POSSIBLE WITH XAMARIN FORMS

			/* Handle Events */
			pictureListView.ItemTapped += (object sender, ItemTappedEventArgs e) => { pictureListView.SelectedItem = null; };

			Padding = new Thickness (0, Device.OnPlatform (20, 0, 0), 0, 0);

			// set the content of the page
			this.Content = new StackLayout 
			{
				Children = { pictureListView }
			};

			ToolbarItems.Add (new ToolbarItem ("", "camera.png", () => 
				{
					/***********************************************************/
					/* HERE --> PUSH ASYNC A NEW TABBED PAGE TO TEST TO SEE IF */
					/* YOU CAN CHANGE PICTUREATPLACEPAGE TO A TABBED PAGE      */
					/***********************************************************/
					DisplayAlert("Camera", "You clicked the camera button!", "OK",null);
				}));
		}
	}
}

