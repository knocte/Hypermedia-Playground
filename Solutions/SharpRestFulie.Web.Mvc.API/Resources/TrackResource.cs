using Restfulie.Server;
using SharpRestFulie.Web.Mvc.Controllers;

namespace SharpRestFulie.Web.Mvc.Resources
{
	public class TrackResource : IBehaveAsResource
	{
		private readonly int _id;
		public string Name { get; set; }
		public string Description { get; set; }

		public TrackResource() : this(int.MinValue)
		{
		}

		public TrackResource(int id)
		{
			_id = id;
		}

		public void SetRelations(Relations relations)
		{
			if (_id > int.MinValue)
			{
				relations.Named("self").Uses<TracksController>().Get(_id);
				relations.Named("add to basket").At("http://sharprestfulie.local/Baskets/{BasketId}/Add");
			}

			relations.Named("list").Uses<TracksController>().Index();
		}
	}
}