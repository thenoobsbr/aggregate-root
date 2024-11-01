namespace TheNoobs.AggregateRoot.UnitTests.Stubs;

public class OrderItem : Entity<long, string>
{
    public OrderItem(long id) : base(id)
    {
    }
}
