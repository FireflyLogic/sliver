using System;
using System.Collections.Generic;
using sliver;



namespace Sliver.Shared
{
	public class PictureViewModel
	{
		public List<Picture> pictureList;

		public PictureViewModel ()
		{
			pictureList = new List<Picture> 
			{
				/* random made-up list... will fill with real pictures later */
				new Picture
				{
					Creator = "CrazyBubbles90",
					DateAndTime = new DateTime(2014, 2, 14, 9, 15, 30),
					ImageUrl = "http://jenisplendid.typepad.com/.a/6a00e5506b3b97883401538f648420970b-pi"
				},

				new Picture
				{
					Creator = "xX_gr3nad3_Xx",
					DateAndTime = new DateTime(2014, 3, 20, 12, 35, 24),
					ImageUrl = "http://elizabethgatlin.com/wp-content/uploads/2013/04/Opening-a-Restaurant-The-Pharmacy-East-Nashville.jpg"
				},

				new Picture
				{
					Creator = "User428389",
					DateAndTime = new DateTime(2014, 5, 13, 16, 38, 59),
					ImageUrl = "http://media-cdn.tripadvisor.com/media/photo-s/03/1d/89/4f/mas-tacos.jpg"
				},

				new Picture
				{
					Creator = "littleMiss87",
					DateAndTime = new DateTime(2014, 7, 10, 10, 12, 23),
					ImageUrl = "http://www.marcheartisanfoods.com/images/home/marche1.jpg"
				}
			};
		}
	}
}

