using NUnit.Framework;
using RestfulieClient.resources;

namespace SharpRestFulie.Consumer
{
	[TestFixture]
	public class ConsumerTests
	{
		[Test]
		public void Given_A_User_Wants_To_Buy_Tracks_And_Get_A_Receipt()
		{
			//Entry end-points should be retrieved from root and include:
				//Tracks
				//Baskets

			dynamic basket = null;
			dynamic tracks = Restfulie.At("http://sharprestfulie.local/tracks/").Accepts("application/json").Get();

			if (basket == null)
			{
				basket = Restfulie.At("http://sharprestfulie.local/baskets").Accepts("application/json").Create(string.Empty);
			}

			var i = 0;
			while (basket.Link["SubmitPayment"] == null)
			{
				if (i > tracks.Length)
				{
					i = 0;
				}

				tracks[i].AddToBasket(basket.Id);
				i++;
			}

			var receipt = basket.SubmitPayment();
			Assert.That(receipt.TotalPaid, Is.EqualTo(20.0));
		}
	}
}
