using System;
using Xamarin.Forms;

namespace sliver
{
	public class LoginPage: ContentPage
	{
		public LoginPage ()
		{
			Title = "Login";

			var username = new Entry ()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			// username.SetBinding(Entry.TextProperty, "Username");
		}
	}
}

