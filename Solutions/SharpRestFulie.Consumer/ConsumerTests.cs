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


			/*
			 * This proof of concept can be summed up as follows: 
				 * 1) Analyse;
				 * 2) Verify Expectations;
				 * 3) Follow Expectations (if verified).
			 */
			var i = 0;
			while (basket.Link["SubmitPaymentPost"] == null)
			{
				if (i >= tracks.Length)
				{
					i = 0;
				}

				tracks[i].AddToBasketPost(basket.Id);
				i++;
			}


			var payment = basket.SubmitPaymentPost();
			Assert.That(payment.Reference, Is.EqualTo(1));
		}
	}
}
