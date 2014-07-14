using System;
using System.Collections.Generic;
using Sliver.SDK.Model;

namespace Sliver.SDK.Service
{
	public interface IPhotoService
	{
		List<Photo> GetPhotosNearLocation(double latitude, double longitude);
		void UploadPhoto (string creator, DateTime timeTaken, double latitude, double longitude, string photoPath);
	}
}

