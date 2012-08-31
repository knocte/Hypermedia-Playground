using System;
using System.Web.Mvc;
using Restfulie.Server;
using Restfulie.Server.Results;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using SharpRestFulie.Domain;
using SharpRestFulie.Web.Mvc.Controllers.Resources;

namespace SharpRestFulie.Web.Mvc.Controllers
{
	[ActAsRestfulie]
	public class PaymentsController : Controller
	{
		private readonly IRepository<Payment> _paymentsRepository;
		private readonly IRepository<Basket> _basketsRepository;

		public PaymentsController() : this(new NHibernateRepository<Payment>(), new NHibernateRepository<Basket>())
		{
		}

		public PaymentsController(IRepository<Payment> paymentsRepository, IRepository<Basket> basketsRepository)
		{
			_paymentsRepository = paymentsRepository;
			_basketsRepository = basketsRepository;
		}


		public virtual ActionResult Get(int id)
		{
			PaymentResource paymentResource;

			try
			{
				var payment = _paymentsRepository.Get(id);

				if (payment == null)
					return new NotFound();

				paymentResource = new PaymentResource()
				                  	{
				                  		TotalPaid = 20.0 //proofs of concept... ... ... are time limited...
				                  	};
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			return new OK(paymentResource);
		}


		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Save(int basketId)
		{
			Payment payment;

			try
			{
				var basket = _basketsRepository.Get(basketId);

				if (basket == null)
					return new BadRequest();
			
				payment = new Payment {Basket = basket};
				_paymentsRepository.SaveOrUpdate(payment);
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			return new Created(payment, "http://sharprestfulie.local/Payments/" + payment.Id);
		}
	}
}