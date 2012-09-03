using System.Collections.Generic;
using System.Linq;
using Restfulie.Server;

namespace SharpRestFulie.Web.Mvc.Controllers.Resources
{
	public class BasketResource : IBehaveAsResource
	{
		private readonly int _id;
		public IList<TrackResource> Tracks { get; set; }

		public BasketResource(int id, IList<TrackResource> tracks)
		{
			_id = id;
			Tracks = tracks;
		}

		public void SetRelations(Relations relations)
		{
			relations.Named("self").Uses<BasketsController>().Get(_id);
			
			//TODO: Comment current Business Process
			relations.Named("SubmitPaymentPost").At("http://sharprestfulie.local/Payments");

			//TODO: Uncomment new Business Process
			//var basketPrice = Tracks.Sum(x => x.Price);

			//if (basketPrice >= 3)
			//{
			//    relations.Named("submit payment").Uses<PaymentsController>().Create(this);
			//}
		}
	}
}