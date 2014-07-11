using System;
using Sliver.Shared.Service;
using System.Collections.Generic;
using sliver;

namespace Sliver.Shared
{
	public class PhotoServiceStub: IPhotoService
	{
		public PhotoServiceStub ()
		{
		}


		public List<Picture> GetPhotosNearLocation (double latitude, double longitude)
		{
			return new List<Picture> 
			{
				new Picture
				{
					Creator = "CrazyBubbles90",
					DateAndTime = new DateTime(2014, 2, 14, 9, 15, 30),
					ImageUrl = "jenis.jpg"
				},

				new Picture
				{
					Creator = "xX_gr3nad3_Xx",
					DateAndTime = new DateTime(2014, 3, 20, 12, 35, 24),
					ImageUrl = "thePharmacy.jpg"
				},

				new Picture
				{
					Creator = "User428389",
					DateAndTime = new DateTime(2014, 5, 13, 16, 38, 59),
					ImageUrl = "masTacos.jpg"
				},

				new Picture
				{
					Creator = "littleMiss87",
					DateAndTime = new DateTime(2014, 7, 10, 10, 12, 23),
					ImageUrl = "marche.jpg"
				}
			};
		}

		public void UploadPhoto (string creator, DateTime timeTaken, double latitude, double longitude, string photoPath)
		{
		}
	}
}

