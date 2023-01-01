using menu_api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace menu_api.Services;
public class MenuItemService
{
    private readonly IMongoCollection<MenuItem> _menuCollection;
    public MenuItemService(IOptions<MenuDatabaseSettings> menuDatabaseSettings)
	{
        var mongoClient = new MongoClient(
            menuDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            menuDatabaseSettings.Value.DatabaseName);

        _menuCollection = mongoDatabase.GetCollection<MenuItem>(
            menuDatabaseSettings.Value.BooksCollectionName);
    }

    public async Task<List<MenuItem>> GetAsync()
    {
        return await _menuCollection.Find(_ => true).ToListAsync();
    }

    public async Task<MenuItem?> GetAsync(string id) =>
        await _menuCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(MenuItem newBook) =>
        await _menuCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, MenuItem updatedBook) =>
        await _menuCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _menuCollection.DeleteOneAsync(x => x.Id == id);


}
