using System;
using System.Collections.Generic;
using Xamarin.Forms;
using sliver;
using Sliver.SDK.Service;

namespace Sliver.Shared
{
	public class PictureViewModel
	{
		public List<Picture> pictureList;

		public PictureViewModel ()
		{
			var service = DependencyService.Get<IPhotoService> ();

			pictureList = new List<Picture> ();

			var photos = service.GetPhotosNearLocation (0, 0);

			foreach (var p in photos)
			{
				pictureList.Add (new Picture () {
					Creator = p.Creator,
					DateAndTime = p.TimeTaken,
					ImageUrl = p.Url,
				});
			}

		}
	}
}

