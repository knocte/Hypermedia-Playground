using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Restfulie.Server;
using Restfulie.Server.Results;
using SharpArch.Domain.PersistenceSupport;
using SharpRestFulie.Domain;

namespace SharpRestFulie.Web.Mvc.Controllers
{
	[ActAsRestfulie]
    public class ItemsController : Controller
    {
		private readonly IRepository<Item> _itemsRepository;

		public ItemsController(IRepository<Item> itemsRepository)
		{
			_itemsRepository = itemsRepository;
		}

		public virtual ActionResult Index()
		{
			IList<Item> items = null;

			try
			{
				items = _itemsRepository.GetAll();
			}
			catch (Exception exception)
			{
				//log exception...
				return new InternalServerError();
			}

			return new OK(items);
		}
    }
}
