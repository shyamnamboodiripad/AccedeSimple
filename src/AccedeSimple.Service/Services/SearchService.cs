using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;

namespace AccedeSimple.Service.Services;

public class SearchService
{
    private readonly VectorStoreCollection<int, Document> _collection;
    public SearchService(VectorStoreCollection<int, Document> collection)
    {
        _collection = collection;
    }

    public async IAsyncEnumerable<Document> SearchAsync(string query)
    {
        await foreach (var result in _collection.SearchAsync(query, top: 5))
        { 
            yield return result.Record;
        }
    }
}