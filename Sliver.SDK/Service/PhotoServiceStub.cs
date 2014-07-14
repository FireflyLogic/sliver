using System;
using System.Collections.Generic;
using Sliver.SDK.Model;

namespace Sliver.SDK.Service
{
	public class PhotoServiceStub: IPhotoService
	{
		public PhotoServiceStub ()
		{
		}


		public List<Photo> GetPhotosNearLocation (double latitude, double longitude)
		{
			return new List<Photo> 
			{
				new Photo
				{
					Creator = "CrazyBubbles90",
					TimeTaken = new DateTime(2014, 2, 14, 9, 15, 30),
					Url = "http://s3.amazonaws.com/sliver/jenis.jpg"
				},

				new Photo
				{
					Creator = "xX_gr3nad3_Xx",
					TimeTaken = new DateTime(2014, 3, 20, 12, 35, 24),
					Url = "http://s3.amazonaws.com/sliver/thePharmacy.jpg"
				},

				new Photo
				{
					Creator = "User428389",
					TimeTaken = new DateTime(2014, 5, 13, 16, 38, 59),
					Url = "http://s3.amazonaws.com/sliver/masTacos.jpg"
				},

				new Photo
				{
					Creator = "littleMiss87",
					TimeTaken = new DateTime(2014, 7, 10, 10, 12, 23),
					Url = "http://s3.amazonaws.com/sliver/marche.jpg"
				}
			};
		}

		public void UploadPhoto (string creator, DateTime timeTaken, double latitude, double longitude, string photoPath)
		{
		}
	}
}
