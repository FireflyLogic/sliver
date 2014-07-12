using System;

namespace Sliver.SDK.Model
{
	public class Photo
	{
		public Photo ()
		{
		}

		public string Creator { get; set; }
		public string Url { get; set; }
		public DateTime TimeTaken { get; set; }
		public double LocationLatitude { get; set; }
		public double LocationLongtude { get; set; }
	}
}

