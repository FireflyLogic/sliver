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
			loginButton.Clicked += (object sender, EventArgs e) => 
			{
				DisplayAlert("Login Clicked", "Creating an account...", "OK", null);
			};

			Content = new StackLayout 
			{
				Spacing = 30,
				Padding = new Thickness(5, 30, 5, 5),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.StartAndExpand,
				Children =
				{
					usernameLabel,
					usernameEntry,
					loginButton
				}
			};
		}
	}
}

