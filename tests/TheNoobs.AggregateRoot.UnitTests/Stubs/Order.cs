namespace TheNoobs.AggregateRoot.UnitTests.Stubs;

public class Order : AggregateRoot<long, string>
{
    public Order(long id) : base(id)
    {
    }

    protected override string ExternalIdGenerator()
    {
        return Guid.NewGuid().ToString();
    }
}
