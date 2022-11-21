using RedisSample.API.Models;

namespace RedisSample.API.Abstractions;

public interface IProductsRepository
{
    /// <summary>
    /// Adds a new product
    /// </summary>
    /// <param name="product">Product info</param>
    /// <returns></returns>
    Task<Product> Create(Product product);

    /// <summary>
    /// Gets a product with id
    /// </summary>
    /// <param name="id">Product's unique Id</param>
    /// <returns></returns>
    Task<Product> GetProduct(string id);

    /// <summary>
    /// Gets all products
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Product>> GetProducts();


    /// <summary>
    /// Updates an existing product 
    /// </summary>
    /// <param name="product">Product's info</param>
    /// <returns></returns>
    Task<Product> UpdateProduct(Product product);
}
