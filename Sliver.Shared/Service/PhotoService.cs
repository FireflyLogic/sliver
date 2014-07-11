using System;
using System.Collections.Generic;
using sliver;

namespace Sliver.Shared.Service
{
	public class PhotoService: IPhotoService
	{
		public PhotoService ()
		{
		}

		public List<Picture> GetPhotosNearLocation (double latitude, double longitude)
		{
			throw new NotImplementedException ();
		}

		public void UploadPhoto (string creator, DateTime timeTaken, double latitude, double longitude, string photoPath)
		{
			throw new NotImplementedException ();
		}
	}
}

