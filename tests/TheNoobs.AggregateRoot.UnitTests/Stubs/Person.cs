namespace TheNoobs.AggregateRoot.UnitTests.Stubs;

public class Person : AggregateRoot<long, Guid>
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

public class Company : Person
{
    public Company(long id, string name) : base(id, name)
    {
    }

    public Company(string name) : base(name)
    {
    }
}
