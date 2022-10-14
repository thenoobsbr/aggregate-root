namespace TheNoobs.AggregateRoot;

/// <summary>
/// Abstract class of entity.
/// </summary>
public abstract class Entity<TId> : IEquatable<Entity<TId>>
{
    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    /// <param name="id">Entity identification.</param>
    protected Entity(TId? id)
    {
        Id = id;
    }
    
    /// <summary>
    /// Initializes a new instance.
    /// </summary>
    protected Entity() : this(default)
    {
    }

    /// <summary>
    /// Get Identification.
    /// </summary>
    public Id<TId> Id { get; }

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

        if (other.GetType() != GetType())
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
    /// Check if first value object and another are the same.
    /// </summary>
    /// <param name="left">First value object.</param>
    /// <param name="right">Last value object.</param>
    /// <returns>True if <paramref name="left"/> is equal to <paramref name="right"/>.</returns>
    public static bool operator ==(Entity<TId> left, Entity<TId> right)
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
    public static bool operator !=(Entity<TId> left, Entity<TId> right)
    {
        return !(left == right);
    }

    /// <inheritdoc cref="Object"/>
    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
