using Restfulie.Server;

namespace SharpRestFulie.Web.Mvc.Controllers.Resources
{
	public class TrackResource : IBehaveAsResource
	{
		private readonly int _id;
		public string Name { get; set; }
		public string Description { get; set; }
		public double Price { get; set; }

		public TrackResource(int id)
		{
			_id = id;
		}

		public void SetRelations(Relations relations)
		{
			relations.Named("self").Uses<TracksController>().Get(_id);
			relations.Named("AddToBasket").At("http://sharprestfulie.local/Baskets/{BasketId}/Add");

			relations.Named("list").Uses<TracksController>().Index();
		}
	}
}