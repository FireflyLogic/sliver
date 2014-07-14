using System;
using Xamarin.Forms;
using Xamarin.Media;
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

			// set the content of the page
			this.Content = new StackLayout 
			{
				Children = { pictureListView }
			};

			ToolbarItems.Add (new ToolbarItem ("Refresh", "refresh.png", () => 
				{
					Console.WriteLine ("--> Refresh clicked");
				}
			));

			#if __IOS__
			ToolbarItems.Add(new ToolbarItem("Camera", "camera.png", async () => 
				{
					var picker = new MediaPicker ();

					if (!picker.IsCameraAvailable) { Console.WriteLine ("No camera!"); }
					else 
					{
						try 
						{
							MediaFile file = await picker.TakePhotoAsync (new StoreCameraMediaOptions 
								{
									Name = "test.jpg",
									Directory = "MediaPickerSample"
								}
							);

							Console.WriteLine (file.Path);
						} 
						catch (OperationCanceledException) 
						{
							Console.WriteLine ("Canceled");
						}
					}
				}
			));
			#endif

			#if __ANDROID__
			ToolbarItems.Add(new ToolbarItem("Camera", "camera.png", async () =>
				{
					var picker = new MediaPicker (Android.App.Application.Context);

					if (!picker.IsCameraAvailable)
					{
						Console.WriteLine ("No camera!");
					}
					else 
					{
//						var intent = picker.GetTakePhotoUI (new StoreCameraMediaOptions 
//							{
//								Name = "test.jpg",
//								Directory = "MediaPickerSample"
//							}
//						);
//
//						((Activity)Forms.Context).StartActivityForResult(intent, 1);
						try 
						{
							MediaFile file = await picker.TakePhotoAsync (new StoreCameraMediaOptions 
								{
									Name = "test.jpg",
									Directory = "MediaPickerSample"
								}
							);

							Console.WriteLine (file.Path);
						} 
						catch (OperationCanceledException) 
						{
							Console.WriteLine ("Canceled");
						}
					}
				}
			));
			#endif
		}

		#if __ANDROID__
		protected async void OnActivityResult (int requestCode, Result resultCode, Intent data)
		{
			Console.WriteLine ("-----> On Activity Result");
			// User canceled
			if (resultCode == Result.Canceled)
				return;

			MediaFile file = await data.GetMediaFileExtraAsync (Android.App.Application.Context);
			Console.WriteLine (file.Path);
		}
		#endif
	}
}

