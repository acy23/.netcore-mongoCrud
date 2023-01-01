using menu_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace menu_api.Services;
public abstract class MongoOpsService<T> : IMongoOpsService<T, string> where T : MongoDbEntity, new()
{
    private readonly IMongoCollection<T> _collection;
    public MongoOpsService(IOptions<MenuDatabaseSettings> menuDatabaseSettings)
	{
        var mongoClient = new MongoClient(
            menuDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            menuDatabaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<T>(
            menuDatabaseSettings.Value.Collection);
    }

    public async Task<List<T>> GetAsync()
    {
        return await _collection.Find(_ => true).ToListAsync();
    }

    public async Task<T?> GetAsync(string id)
    {
        return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task CreateAsync(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(string id, T entity)
    {
        await _collection.ReplaceOneAsync(x => x.Id == id, entity);
    }

    public async Task DeleteAsync(string id)
    {
        await _collection.DeleteOneAsync(x => x.Id == id);
    }

}
