﻿using System;
using Xamarin.Forms;
using Xamarin.Media;
using Sliver.SDK;
using Xamarin.Forms.Labs.Services.Media;


#if __ANDROID__
using Android.App;
using Android.Content;
#endif


namespace Sliver.Shared
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
			var cameraViewModel = new CameraViewModel ();

			/* create UI of page */
			// create the list view
			var pictureListView = new ListView {
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
			pictureListView.ItemTapped += (object sender, ItemTappedEventArgs e) => {
				pictureListView.SelectedItem = null;
			};

			// set the content of the page
			this.Content = new StackLayout {
				Children = { pictureListView }
			};

			ToolbarItems.Add (new ToolbarItem ("Refresh", "refresh.png", () => {
				Console.WriteLine ("--> Refresh clicked");
			}
			));

			ToolbarItems.Add (new ToolbarItem 
				{
					Name = "Camera",
					Icon = "camera.png",
					Command = cameraViewModel.TakePictureCommand
				}
			);
		}
	}
}

