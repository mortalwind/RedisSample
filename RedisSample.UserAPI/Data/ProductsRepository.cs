using Redis.OM.Searching;
using Redis.OM;

using RedisSample.UserAPI.Abstractions;
using RedisSample.UserAPI.Models;

namespace RedisSample.UserAPI.Data;

public class ProductsRepository : IProductsRepository
{
    private readonly RedisConnectionProvider _provider;
    private readonly RedisCollection<Product> _products;

    public ProductsRepository(RedisConnectionProvider provider)
    {
        _provider = provider;
        _products = (RedisCollection<Product>)provider.RedisCollection<Product>();

    }

    public async Task<Product> Create(Product product)
    {
        if (product is null)
        {
            return await Task.FromException<Product>(new ArgumentOutOfRangeException(nameof(product)));
        }
        await _products.InsertAsync(product);

        return product;
    }

    public async Task<Product> GetProduct(string id)
    {
        return await _products.SingleOrDefaultAsync(product => product.Id.Equals(id)) ?? new Product();
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _products.ToListAsync() ?? new List<Product>();
    }

    public async Task<Product> UpdateProduct(Product product)
    {
        if (product is null)
        {
            return await Task.FromException<Product>(new ArgumentOutOfRangeException(nameof(product)));
        }
        await _products.UpdateAsync(product);
        return await GetProduct(product.Id);
    }
}
