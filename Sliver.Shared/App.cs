using System;
using Xamarin.Forms;
using Sliver.Shared;

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
