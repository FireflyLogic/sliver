using System;
using System.Collections.Generic;
using sliver;
using Xamarin.Forms;
using Sliver.Shared.Service;



namespace Sliver.Shared
{
	public class PictureViewModel
	{
		public List<Picture> pictureList;

		public PictureViewModel ()
		{
			var service = DependencyService.Get<IPhotoService> ();

			pictureList = service.GetPhotosNearLocation (0, 0);
		}
	}
}

