namespace SharpRestFulie.Domain
{
    using SharpArch.Domain.DomainModel;

    public class Item : Entity
    {
		public virtual string Name { get; set; }
		public virtual string Description { get; set; }
    }
}