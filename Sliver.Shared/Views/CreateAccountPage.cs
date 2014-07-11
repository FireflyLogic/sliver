using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Sliver.Shared
{
	public class CreateAccountPage: ContentPage
	{
		public CreateAccountPage ()
		{
			// set title of page
			Title = "Create an Account";

			// set background image of page
			BackgroundImage = "background.jpg";

			// create username label
			var usernameLabel = new Label () 
			{
				Text = "Username",
				Font = Font.BoldSystemFontOfSize(30),
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			// create username entry field
			var usernameEntry = new Entry ()
			{
				Placeholder = "Enter a username",
				WidthRequest = 300,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

			// create the activity indicator
			ActivityIndicator spinner = new ActivityIndicator 
			{
				Color = Device.OnPlatform(
					Color.White,
					Color.Default,
					Color.Default
				),
				IsRunning = true,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};

			// create the loading label
			var loadingLabel = new Label () 
			{
				Text = "Creating New Account...",
				TextColor = Color.Teal,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};

			// create the create account button
			var loginButton = new Button () 
			{
				Text = "Let's Go!",
				TextColor = Color.White,
				Font = Font.BoldSystemFontOfSize(18),
				BorderColor = Color.Teal,
				BorderRadius = 20,
				BorderWidth = 2,
				WidthRequest = 200,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			// Add padding to the UI
			Padding = new Thickness (5, Device.OnPlatform (20, 5, 5), 5, 5);

			// Set the content of the page
			var stackLayout = new StackLayout 
			{
				Spacing = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children = {
					usernameLabel,
					usernameEntry,
					loginButton
				}
			};

			Content = stackLayout;

			/* Handle Events */
			loginButton.Clicked += (object sender, EventArgs e) => 
			{
				CreateNewAccount(stackLayout, usernameEntry, loginButton, loadingLabel, spinner);
			};

			usernameEntry.Completed += (object sender, EventArgs e) => 
			{
				CreateNewAccount(stackLayout, usernameEntry, loginButton, loadingLabel, spinner);
			};
		}

		async void  CreateNewAccount (StackLayout layout, Entry usernameEntry, Button loginButton, Label loadingLabel, ActivityIndicator spinner)
		{
			if (usernameEntry.Text == null || usernameEntry.Text.Length == 0) 
			{
				await DisplayAlert ("Oops!", "The username is missing! You need one to create an account.", "OK", null);
			} 
			else 
			{
				layout.Children.Remove (loginButton);
				layout.Children.Add (loadingLabel);
				layout.Children.Add (spinner);

				/* API call -- create new account with given username */
				await Task.Delay (2000);

				layout.Children.Remove (loadingLabel);
				layout.Children.Remove (spinner);

				await Navigation.PushModalAsync (new NavigationPage( new TabbedPage 
					{ 
						BackgroundColor = Color.Black,
						ToolbarItems = 
						{
							new ToolbarItem("", "refresh.png", () =>
								{
									DisplayAlert("Refresh", "You clicked the refresh button!", "OK", null);
								}
							),

							new ToolbarItem ("", "camera.png", () => 
								{
									DisplayAlert("Camera", "You clicked the camera button!", "OK", null);
								}
							)
						},

						Children = 
						{ 
							new PicturesAtPlacePage
							{
								Icon = "picture.png"
							},

							new MapViewPage
							{
								Icon = "map.png"
							}
						} 
					}
				)
					{
						// tint the nav bar 
						Tint = Color.Silver
					}
				);
			}
		}
	}
}

