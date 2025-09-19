namespace TheNoobs.AggregateRoot;

/// <summary>
/// Abstract class of entity.
/// </summary>
/// <typeparam name="TId">The type of the entity identification.</typeparam>
public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : IEquatable<TId>
{
    #if NET9_0
    private readonly Guid _transientId = Guid.CreateVersion7();
    #else
    private readonly Guid _transientId = Guid.NewGuid();
    #endif
    
    /// <summary>
    /// Initializes a new instance, explicitly setting an identification.
    /// </summary>
    /// <param name="id">Entity identification.</param>
    protected Entity(TId id)
    {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    protected Entity() : this(default!)
    {
    }

    /// <summary>
    /// Get Identification.
    /// </summary>
    public TId Id { get; private set; }

    /// <summary>
    /// Compare current entity to another entity.
    /// </summary>
    /// <param name="other">Entity instance.</param>
    /// <returns>True if <paramref name="other"/> is equal to the current instance.</returns>
    public virtual bool Equals(Entity<TId>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        if (Equals(Id, default(TId)) || Equals(other.Id, default(TId)))
        {
            return false;
        }

        return other.Id.Equals(Id);
    }

    /// <summary>
    /// Compare current entity to another object.
    /// </summary>
    /// <param name="obj">Object instance.</param>
    /// <returns>True if <paramref name="obj"/> is equal to the current instance.</returns>
    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> other && Equals(other);
    }

    /// <summary>
    /// Specify if current entity is satisfied by another entity.
    /// It almost equivalent to Equals method. But it returns true
    /// when the other instance inherits the current type.
    /// </summary>
    /// <param name="other">Other entity instance.</param>
    /// <returns>True if <paramref name="other"/> is equal to the current instance.</returns>
    public bool IsSatisfiedBy(Entity<TId>? other)
    {
        if (other is null)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (!GetType().IsInstanceOfType(other))
        {
            return false;
        }

        if (Equals(Id, default(TId)) || Equals(other.Id, default(TId)))
        {
            return false;
        }

        return other.Id.Equals(Id);
    }

    /// <summary>
    /// Check if first value object and another are the same.
    /// </summary>
    /// <param name="left">First value object.</param>
    /// <param name="right">Last value object.</param>
    /// <returns>True if <paramref name="left"/> is equal to <paramref name="right"/>.</returns>
    public static bool operator ==(Entity<TId>? left, Entity<TId>? right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        return left.Equals(right);
    }

    /// <summary>
    /// Check if first value object and another are different.
    /// </summary>
    /// <param name="left">First value object.</param>
    /// <param name="right">Last value object.</param>
    /// <returns>True if <paramref name="left"/> is equal to <paramref name="right"/>.</returns>
    public static bool operator !=(Entity<TId>? left, Entity<TId>? right)
    {
        return !(left == right);
    }

    private object GetId()
    {
        return Equals(Id, default(TId)) ? _transientId : Id;
    }

    /// <inheritdoc cref="Object"/>
    public override int GetHashCode()
    {
        return GetId().GetHashCode();
    }
}

/// <summary>
/// Abstract class of entities with an external identification.
/// </summary>
/// <typeparam name="TId">The type of the entity identification.</typeparam>
/// <typeparam name="TExternalId">The type of the entity external identification.</typeparam>
public abstract class Entity<TId, TExternalId> : Entity<TId>
    where TId : IEquatable<TId>
    where TExternalId : IEquatable<TExternalId>
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    protected Entity()
    {
        InitializeExternalId();
    }

    /// <summary>
    /// Initializes a new instance, explicitly setting an identification.
    /// </summary>
    /// <param name="id">Entity identification.</param>
    protected Entity(TId id) : base(id)
    {
        InitializeExternalId();
    }

    /// <summary>
    /// Initializes a new instance, explicitly setting both identification and external identification.
    /// </summary>
    /// <param name="id">Entity identification.</param>
    /// <param name="externalId">Entity external identification.</param>
    protected Entity(TId id, TExternalId externalId) : base(id)
    {
        ExternalId = externalId;
    }

    /// <summary>
    /// Gets the external identification of the entity.
    /// </summary>
    public TExternalId ExternalId { get; private set; } = default!;

    private void InitializeExternalId()
    {
        ExternalId = ExternalIdGenerator();
    }

    /// <summary>
    /// The default implementation to generate new external identifications.
    /// </summary>
    /// <returns>A unique external identification to be used when creating a new entity.</returns>
    /// <remarks>
    /// This default implementation only supports generating Guids as external identifications.
    /// To implement the generation of a new type of external identification, override the
    /// <see cref="ExternalIdGenerator"/> method.
    /// </remarks>
    /// <exception cref="NotImplementedException">
    /// Throws when the type of the external identification is not a Guid.
    /// </exception>
    protected virtual TExternalId ExternalIdGenerator()
    {
        object? externalId = null;
        
        if (typeof(TExternalId) == typeof(Guid))
        {
            #if NET9_0_OR_GREATER
            externalId = Guid.CreateVersion7();
            #else
            externalId = Guid.NewGuid();
            #endif
        }

        if (externalId is not null)
        {
            return (TExternalId)Convert.ChangeType(externalId, typeof(TExternalId));
        }

        throw new NotSupportedException(
            $"Default implementation of {nameof(ExternalIdGenerator)} does not have a generator strategy for " +
            $"{typeof(TExternalId).Name}. To implement a new strategy, override the {nameof(ExternalIdGenerator)} " +
            "default implementation.");
    }
}
