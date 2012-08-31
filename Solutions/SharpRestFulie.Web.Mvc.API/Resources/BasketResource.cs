using System.Collections.Generic;

namespace SharpRestFulie.Web.Mvc.Resources
{
	public class BasketResource
	{
		public IList<TrackResource> Tracks { get; set; }

		public BasketResource(IList<TrackResource> tracks)
		{
			Tracks = tracks;
		}
	}
}