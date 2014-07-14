using System;
//using Newtonsoft.Json;

namespace Sliver.SDK.Model
{
	public class Photo
	{
		public Photo ()
		{
		}

//		[JsonProperty(PropertyName = "creator")]
		public string Creator { get; set; }

//		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

//		[JsonProperty(PropertyName = "timeTaken")]
		public DateTime TimeTaken { get; set; }

//		[JsonProperty(PropertyName = "locationLatitude")]
		public double LocationLatitude { get; set; }

//		[JsonProperty(PropertyName = "locationLonitude")]
		public double LocationLongtude { get; set; }
	}
}

