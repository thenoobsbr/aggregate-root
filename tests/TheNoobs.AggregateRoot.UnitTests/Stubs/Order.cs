namespace TheNoobs.AggregateRoot.UnitTests.Stubs;

public class Order : AggregateRoot<long>
{
    public Order(long id) : base(id)
    {
    }
}
