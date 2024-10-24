namespace TheNoobs.AggregateRoot.Abstractions;

public interface IAggregateRoot
{
    /// <summary>
    /// Get read only list of domain events. 
    /// </summary>
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// Clear list of domain events.
    /// </summary>
    public void ClearDomainEvents();
}
