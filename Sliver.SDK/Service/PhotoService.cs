using System;
using System.Collections.Generic;
using Sliver.SDK.Model;

namespace Sliver.SDK.Service
{
	public class PhotoService: IPhotoService
	{
		public PhotoService ()
		{
		}

		public List<Photo> GetPhotosNearLocation (double latitude, double longitude)
		{
			throw new NotImplementedException ();
		}

		public void UploadPhoto (string creator, DateTime timeTaken, double latitude, double longitude, string photoPath)
		{
			throw new NotImplementedException ();
		}
	}
}

