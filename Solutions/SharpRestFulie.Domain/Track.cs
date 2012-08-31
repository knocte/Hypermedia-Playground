using SharpArch.Domain.DomainModel;

namespace SharpRestFulie.Domain
{
	public class Track : Entity
	{
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
	}
}