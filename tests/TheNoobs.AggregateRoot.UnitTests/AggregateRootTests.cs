using FluentAssertions;
using TheNoobs.AggregateRoot.Abstractions;
using TheNoobs.AggregateRoot.UnitTests.Stubs;

namespace TheNoobs.AggregateRoot.UnitTests;

public class AggregateRootTests
{
    [Fact(DisplayName = @"GIVEN aggregate_root, SHOULD clear domain event")]
    public void Given_aggregate_root_should_clear_domain_event()
    {
        IAggregateRoot person = new Person("Name");
        person.ClearDomainEvents();

        person.DomainEvents.Should().BeEmpty();
    }

    [Fact(DisplayName = @"GIVEN aggregate_root, SHOULD raise domain event")]
    public void Given_aggregate_root_should_raise_domain_event()
    {
        IAggregateRoot person = new Person("Name");

        person.DomainEvents.Should().NotBeEmpty();
        person.DomainEvents.OfType<PersonCreated>().Should().NotBeEmpty();
    }
}
