using SharpArch.Domain.DomainModel;

namespace SharpRestFulie.Domain
{
	public class Payment : Entity
	{
		public virtual Basket Basket { get; set; }
	}
}