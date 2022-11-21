using RedisSample.API.Models;

namespace RedisSample.API.Abstractions;

public interface ICartsRepository
{
    /// <summary>
    /// Creates a new cart for an user
    /// </summary>
    /// <param name="cart">Cart info</param>
    /// <returns></returns>
    Task<Cart> Create(Cart cart);

    /// <summary>
    /// Gets an user's cart
    /// </summary>
    /// <param name="userId">User's unique Id</param>
    /// <returns></returns>
    Task<Cart> GetCart(string userId);

    /// <summary>
    /// Clears an existing cart by removing all cart items.
    /// </summary>
    /// <param name="user">Cart's info</param>
    /// <returns></returns>
    Task<Cart> ClearCart(string cartId);

    /// <summary>
    /// Adds a new item to shopping cart
    /// </summary>
    /// <param name="cartId">Cart's unique Id</param>
    /// <param name="item">Cart item info</param>
    /// <returns></returns>
    Task<bool> AddItemToCart(string cartId, CartItem item);

    /// <summary>
    /// Adds a new item to shopping cart
    /// </summary>
    /// <param name="cartId">Cart's unique Id</param>
    /// <param name="itemId">Cart item's unique Id</param>
    /// <returns></returns>
    Task<bool> RemoveItemFromCart(string cartId, string itemId);

}
