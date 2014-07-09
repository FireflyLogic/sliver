using System;
using Xamarin.Forms;

namespace sliver
{
	public class App
	{
		public static Page GetMainPage ()
		{	
			return new NavigationPage (new CreateAccountPage ());
		}
	}
}
