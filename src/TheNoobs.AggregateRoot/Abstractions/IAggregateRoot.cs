namespace TheNoobs.AggregateRoot.Abstractions;

public interface IAggregateRoot
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Clear list of domain events.
    /// </summary>
    public void ClearDomainEvents();
}
