using System;
using System.Collections.Generic;
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
    public class TracksController : Controller
	{
		private readonly IRepository<Track> _tracksRepository;

		public TracksController() : this(new NHibernateRepository<Track>())
		{
		}

		public TracksController(IRepository<Track> tracksRepository)
		{
			_tracksRepository = tracksRepository;
		}


		public virtual ActionResult Index()
		{
			IList<TrackResource> indexTrackResources;

			try
			{
				var tracks = _tracksRepository.GetAll();

				indexTrackResources = new List<TrackResource>();
				foreach (var track in tracks)
				{
					indexTrackResources.Add(new TrackResource(track.Id)
											{
												Name = track.Name,
												Description = track.Description,
												Price = track.Price
											});
				}
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			return new OK(indexTrackResources);
		}

		public virtual ActionResult Get(int id)
		{
			Track track;

			try
			{
				track = _tracksRepository.Get(id);
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			if (track == null) 
				return new NotFound();

			var trackResource = new TrackResource(track.Id)
											{
												Name = track.Name,
												Description = track.Description,
												Price = track.Price
											};

			return new OK(trackResource);
		}
    }
}
