﻿using System;

namespace sliver
{
	public class Picture
	{
		// who took the picture?
		string _creator;
		public string Creator
		{
			get { return _creator; }
			set { _creator = value; }
		}

		// what's the image filename?
		string _imageUrl;
		public string ImageUrl
		{
			get { return _imageUrl; }
			set { _imageUrl = value; }
		}

		// when was this picture taken?
		DateTime _dateAndTime;
		public DateTime DateAndTime
		{
			get { return _dateAndTime; }
			set { _dateAndTime = value; }
		}

		public string DateAndTimeString
		{
			get { return "July 10, 2014 12:35PM"; }
		}


		public Picture ()
		{
		}
	}
}

