namespace menu_api.Models;

public interface IEntity
{
}
public interface IEntity<out TKey> : IEntity where TKey : IEquatable<TKey>
{
    public TKey Id { get; }
}
