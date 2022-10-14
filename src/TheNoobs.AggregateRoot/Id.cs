namespace TheNoobs.AggregateRoot;

public sealed class Id<TId>
{
    private readonly Guid _transientId = Guid.NewGuid();
    private readonly TId? _id;

    public Id(TId? id)
    {
        _id = id;
    }

    public static implicit operator Id<TId>(TId? id) => new(id);
    public static implicit operator TId?(Id<TId> id) => id._id;

    public static bool operator ==(Id<TId> left, object? right)
    {
        if (ReferenceEquals(left, null) && ReferenceEquals(right, null)) return true;
        if (ReferenceEquals(left, null) || ReferenceEquals(right, null)) return false;
        return left.Equals(right);
    }

    public static bool operator !=(Id<TId> left, object? right)
    {
        return !(left == right);
    }

    public override int GetHashCode()
    {
        if (!Equals(_id, default(TId)))
        {
            return _id!.GetHashCode();
        }
        return _transientId.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj is TId innerId)
        {
            return innerId.Equals(_id);
        }

        if (obj is not Id<TId> id)
        {
            return false;
        }

        return GetHashCode().Equals(id.GetHashCode());
    }
}
