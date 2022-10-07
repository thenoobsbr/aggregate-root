using TheNoobs.AggregateRoot.Abstractions;

namespace TheNoobs.AggregateRoot;

/// <summary>
/// Abstract class of Aggregate Root.
/// </summary>
/// <typeparam name="TId">Id type.</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = new();

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="id">Aggegate root identification.</param>
    protected AggregateRoot(TId? id) : base(id)
    {
    }

    /// <summary>
    /// Default constructor.
    /// </summary>
    protected AggregateRoot() : this(default)
    {
    }

    /// <summary>
    /// Get read only list of domain events. 
    /// </summary>
    IReadOnlyCollection<IDomainEvent> IAggregateRoot.DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Raises a new domain event.
    /// </summary>
    /// <param name="domainEvent"></param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clear list of domain events.
    /// </summary>
    void IAggregateRoot.ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
