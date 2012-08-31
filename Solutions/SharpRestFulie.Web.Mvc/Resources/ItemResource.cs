using Restfulie.Server;
using SharpRestFulie.Web.Mvc.Controllers;

namespace SharpRestFulie.Web.Mvc.Resources
{
	public class ItemResource : IBehaveAsResource
	{
		private readonly int _id;
		public string Name { get; set; }
		public string Description { get; set; }

		public ItemResource() : this(int.MinValue)
		{
		}

		public ItemResource(int id)
		{
			_id = id;
		}

		public void SetRelations(Relations relations)
		{
			if (_id > int.MinValue)
				relations.Named("self").Uses<ItemsController>().Get(_id);

			relations.Named("list").Uses<ItemsController>().Index();
		}
	}
}