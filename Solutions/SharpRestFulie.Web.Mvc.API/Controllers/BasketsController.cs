using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Restfulie.Server;
using Restfulie.Server.Results;
using SharpArch.Domain.PersistenceSupport;
using SharpArch.NHibernate;
using SharpRestFulie.Domain;
using SharpRestFulie.Web.Mvc.Resources;

namespace SharpRestFulie.Web.Mvc.Controllers
{
	[ActAsRestfulie]
	public class BasketsController : Controller
	{
		private readonly IRepository<Basket> _basketsRepository;
		private readonly IRepository<Track> _tracksRepository;

		public BasketsController() : this(new NHibernateRepository<Basket>(), new NHibernateRepository<Track>())
		{
		}

		public BasketsController(IRepository<Basket> basketsRepository, IRepository<Track> tracksRepository)
		{
			_basketsRepository = basketsRepository;
			_tracksRepository = tracksRepository;
		}


		public virtual ActionResult Get(int id)
		{
			BasketResource basketResource;

			try
			{
				var basket = _basketsRepository.Get(id);

				if (basket == null)
					return new NotFound();

				var trackResources = new List<TrackResource>();
				foreach (var basketTrack in basket.Tracks)
				{
					trackResources.Add(new TrackResource(basketTrack.Id)
					{
						Name = basketTrack.Name,
						Description = basketTrack.Description
					});
				}

				basketResource = new BasketResource(trackResources);
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			return new OK(basketResource);
		}


		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Create()
		{
			Basket basket;

			try
			{
				basket = new Basket();
				_basketsRepository.SaveOrUpdate(basket);
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			var createdUrl = GetCreatedUrl(basket.Id);
			return new Created(basket, createdUrl);
		}

		private string GetCreatedUrl(int basketId)
		{
			return "http://" + Request.Url.Host + "/Basket/" + basketId;
		}


		//OPTIONS should say this end-point only accepts POST (should actually be PATCH)...
		[AcceptVerbs(HttpVerbs.Post)]
		public virtual ActionResult Update(int id, int trackId)
		{
			try
			{
				var basket = _basketsRepository.Get(id);

				if (basket == null)
					return new BadRequest();

				var track = _tracksRepository.Get(trackId);

				if (track == null)
					return new NotFound();

				basket.Tracks.Add(track);
			
				_basketsRepository.SaveOrUpdate(basket);
				NHibernateSession.Current.Flush();//Flushing the many to many table records... ... ... ... ... (while 1)
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			return Get(id); //TODO: analyse and refactor here...
		}
	}
}