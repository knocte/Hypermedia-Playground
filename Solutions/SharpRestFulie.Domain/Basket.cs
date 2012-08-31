using System.Collections.Generic;
using SharpArch.Domain.DomainModel;

namespace SharpRestFulie.Domain
{
	public class Basket : Entity
	{
		public virtual IList<Track> Tracks { get; set; }
	}
}