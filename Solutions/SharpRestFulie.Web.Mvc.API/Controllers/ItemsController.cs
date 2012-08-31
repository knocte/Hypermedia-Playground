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
    public class ItemsController : Controller
	{
		private readonly IRepository<Item> _itemsRepository;

		public ItemsController() : this(new NHibernateRepository<Item>())
		{
		}

		public ItemsController(IRepository<Item> itemsRepository)
		{
			_itemsRepository = itemsRepository;
		}

		public virtual ActionResult Index()
		{
			IList<ItemResource> itemResources = null;

			try
			{
				var items = _itemsRepository.GetAll();
				itemResources = new List<ItemResource>();

				foreach (var item in items)
				{
					itemResources.Add(new ItemResource(item.Id)
											{
												Name = item.Name,
												Description = item.Description
											});
				}
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			return new OK(itemResources);
		}

		public virtual ActionResult Get(int id)
		{
			var item = _itemsRepository.Get(id);

			if (item == null) 
				return new NotFound();

			var itemResource = new ItemResource(item.Id)
											{
												Name = item.Name,
												Description = item.Description
											};

			return new OK(itemResource);
		}
    }
}
