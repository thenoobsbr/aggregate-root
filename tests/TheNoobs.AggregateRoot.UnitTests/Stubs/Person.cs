namespace TheNoobs.AggregateRoot.UnitTests.Stubs;

public class Person : AggregateRoot<long>
{
    public Person(long id, string name) : base(id)
    {
        Name = name;
    }

    public Person(string name)
    {
        Name = name;
        RaiseDomainEvent(new PersonCreated());
    }

    public string Name { get; }
}
