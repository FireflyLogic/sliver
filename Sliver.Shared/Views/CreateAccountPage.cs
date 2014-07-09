using System;
using Xamarin.Forms;

namespace sliver
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
					Color.Teal,
					Color.Default,
					Color.Default
				),
				IsRunning = true,
				IsVisible = false,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
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

			/* Handle Events */
			loginButton.Clicked += (object sender, EventArgs e) => 
			{
				CreateNewAccount (spinner, loginButton, usernameEntry);
			};

			usernameEntry.Completed += (object sender, EventArgs e) => 
			{
				CreateNewAccount (spinner, loginButton, usernameEntry);
			};

			// Add padding to the UI
			Padding = new Thickness (5, Device.OnPlatform (20, 5, 5), 5, 5);

			// Set the content of the page
			Content = new StackLayout 
			{
				Spacing = 30,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					usernameLabel,
					usernameEntry,
					loginButton,
					spinner
				}
			};
		}

		void CreateNewAccount (ActivityIndicator spinner, Button loginButton, Entry usernameEntry)
		{
			if (usernameEntry.Text == null || usernameEntry.Text.Length == 0) 
			{
				DisplayAlert ("Oops!", "The username is missing! You need one to create an account.", "OK", null);
			} 
			else 
			{
				loginButton.IsVisible = false;
				spinner.IsVisible = true;

				/* API call -- create new account with given username */

				DisplayAlert ("New Account", string.Format ("You have created an account with the username:\n{0}", usernameEntry.Text), "OK", null);
			}
		}
	}
}

