using menu_api.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace menu_api.Services;
public interface IMongoOpsService<T, in TKey> where T : class, IEntity<TKey>, new() where TKey : IEquatable<TKey>
{
    public Task<List<T>> GetAsync();
    public Task<T?> GetAsync(TKey id);
    public Task CreateAsync(T entity);
    public Task UpdateAsync(TKey id, T entity);
    public Task DeleteAsync(TKey id);
}
