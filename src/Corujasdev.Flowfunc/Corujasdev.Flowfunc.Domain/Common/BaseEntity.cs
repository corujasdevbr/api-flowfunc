namespace Corujasdev.Flowfunc.Domain.Common;
public abstract class BaseEntity : IEntity
{
    public Guid Id { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public DateTime? DateDeleted { get; set; }

    public virtual void Deleted() => DateDeleted = DateTime.Now;
    public virtual void Active() => DateDeleted = null;

    public override bool Equals(object? obj)
    {
        var compareTo = obj as BaseEntity;

        //Valida se o tipo do objeto e o id é o mesmo

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id);
    }
    public static bool operator ==(BaseEntity a, BaseEntity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(BaseEntity a, BaseEntity b)
    {
        return !(a == b);
    }

    //Validate to value is unique in entity, do not duplicate objects
    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return $"{GetType().Name} [Id={Id}]";
    }
}

