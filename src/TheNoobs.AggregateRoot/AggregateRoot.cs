using TheNoobs.AggregateRoot.Abstractions;

namespace TheNoobs.AggregateRoot;

/// <summary>
/// Abstract class of Aggregate Root.
/// </summary>
/// <typeparam name="TId">The type of the aggregate root identification.</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot where TId : IEquatable<TId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Initializes a new instance, explicitly setting an identification.
    /// </summary>
    /// <param name="id">Aggregate root identification.</param>
    protected AggregateRoot(TId id) : base(id)
    {
    }

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    protected AggregateRoot()
    {
    }
    
    IReadOnlyCollection<IDomainEvent> IAggregateRoot.DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Raises a new domain event.
    /// </summary>
    /// <param name="domainEvent">The event that should be raised.</param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    void IAggregateRoot.ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

public abstract class AggregateRoot<TId, TExternalId> : Entity<TId, TExternalId>, IAggregateRoot
    where TId : IEquatable<TId>
    where TExternalId : IEquatable<TExternalId>
{
    private readonly List<IDomainEvent> _domainEvents = [];

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="id">Aggregate root identification.</param>
    protected AggregateRoot(TId id) : base(id)
    {
    }
    
    /// <summary>
    /// Initializes a new instance, explicitly setting both identification and external identification.
    /// </summary>
    /// <param name="id">Aggregate root identification.</param>
    /// <param name="externalId">Aggregate root external identification.</param>
    protected AggregateRoot(TId id, TExternalId externalId) : base(id, externalId)
    {
    }

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    protected AggregateRoot()
    {
    }
    
    IReadOnlyCollection<IDomainEvent> IAggregateRoot.DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Raises a new domain event.
    /// </summary>
    /// <param name="domainEvent">The event that should be raised.</param>
    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    
    void IAggregateRoot.ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
