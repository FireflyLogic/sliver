using System;
using System.Collections.Generic;
using Sliver.SDK.Model;
//using Microsoft.WindowsAzure.MobileServices;

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

		public async void UploadPhoto (string creator, DateTime timeTaken, double latitude, double longitude, string photoPath)
		{
			var photo = new Photo () {
				Creator = creator,
				TimeTaken = timeTaken,
				LocationLatitude = latitude,
				LocationLongtude = longitude,
				Url = "",
			};

//			var sliverClient = new Microsoft.WindowsAzure.MobileServices.MobileServiceClient (
//                   "https://sliver.azure-mobile.net/",
//                   "qxvnFuoFNMmBHUPBuVqqLcmJhpeJqn13"
//               );
//
//			await sliverClient.GetTable<Photo>().InsertAsync(photo);
		}
	}
}

