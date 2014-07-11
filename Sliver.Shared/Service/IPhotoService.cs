using System;
using System.Collections.Generic;
using sliver;

namespace Sliver.Shared.Service
{
	public interface IPhotoService
	{
		List<Picture> GetPhotosNearLocation(double latitude, double longitude);
		void UploadPhoto (string creator, DateTime timeTaken, double latitude, double longitude, string photoPath);
	}
}

