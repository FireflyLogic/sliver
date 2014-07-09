using System;


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
		string _imageString;
		public string ImageString
		{
			get { return _imageString; }
			set { _imageString = value; }
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
			get { return "date and time string"; }
		}



		public Picture ()
		{
		}
	}
}

