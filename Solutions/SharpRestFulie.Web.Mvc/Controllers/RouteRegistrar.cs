namespace SharpRestFulie.Web.Mvc.Controllers
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class RouteRegistrar
    {
        public static void RegisterRoutesTo(RouteCollection routes) 
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

			routes.MapRoute(
						   "Get",
						   "{controller}/{id}",
						   new { action = "Get" },
						   new
						   {
							   id = @"\d+"
						   }
						   );

			routes.MapRoute(
				"Save",
				"{controller}/",
				new { action = "Save" },
				new
				{
					httpMethod = new HttpMethodConstraint("POST")
				}
				);

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Items", action = "Index", id = UrlParameter.Optional }); // Parameter defaults
        }
    }
}
