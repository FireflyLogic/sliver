using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Droid;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Platform.Android;


namespace sliver.Android
{
	[Activity (Label = "sliver.Android.Android", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : XFormsApplicationDroid
	{
		private static bool _initialized;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			if (!_initialized)
			{
				this.SetIoc ();
			}

			Xamarin.Forms.Forms.Init (this, bundle);

			SetPage (App.GetMainPage ());
		}

		/// <summary>
		/// Sets the IoC.
		/// </summary>
		private void SetIoc()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppDroid();

			app.Init (this);

			var documents = app.AppDataDirectory;

			resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IDependencyContainer>(resolverContainer)
				.Register<IXFormsApp>(app);


			Resolver.SetResolver(resolverContainer.GetResolver());

			_initialized = true;
		}
	}
}

