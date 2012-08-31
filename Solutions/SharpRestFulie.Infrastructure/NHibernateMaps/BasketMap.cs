using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using SharpRestFulie.Domain;

namespace SharpRestFulie.Infrastructure.NHibernateMaps
{
	public class BasketMap : IAutoMappingOverride<Basket>
	{
		public void Override(AutoMapping<Basket> mapping)
		{
			mapping.HasManyToMany(x => x.Tracks).Cascade.All();
		}
	}
}
