using Redis.OM.Searching;
using Redis.OM;
using RedisSample.UserAPI.Abstractions;
using RedisSample.UserAPI.Models;

namespace RedisSample.UserAPI.Data;

public class CartsRepository : ICartsRepository
{
    private readonly RedisConnectionProvider _provider;
    private readonly RedisCollection<Cart> _carts;

    public CartsRepository(RedisConnectionProvider provider)
    {
        _provider = provider;
        _carts = (RedisCollection<Cart>)provider.RedisCollection<Cart>();
    }


    public async Task<bool> AddItemToCart(string cartId, CartItem item)
    {
        var cart =  await _carts.SingleOrDefaultAsync(cart => cart.Id.Equals(cartId));

        if (cart is not null) {
            var cartItemExist = cart.CartItems.SingleOrDefault(x => x.ProductId.Equals(item.ProductId));
            if (cartItemExist is not null)
            {
                cartItemExist.Quantity += item.Quantity;
            }
            else
            {
                cart.CartItems = new List<CartItem>() {
                    item
                };
            }

            await _carts.UpdateAsync(cart);
            return true;
        }

        return await Task.FromException<bool>(new Exception("User's cart not found"));
    }

    public async Task<Cart> ClearCart(string cartId)
    {
        var cart = await _carts.SingleOrDefaultAsync(cart => cart.Id.Equals(cartId));

        if (cart is not null)
        {
            cart.CartItems = new List<CartItem>();
            
          await _carts.UpdateAsync(cart);
          return cart;
        }

        return await Task.FromException<Cart>(new Exception("User's cart not found"));
    }

    public async Task<Cart> Create(Cart cart)
    {
        if (cart is null)
        {
            return await Task.FromException<Cart>(new ArgumentOutOfRangeException(nameof(cart)));
        }

        await _carts.InsertAsync(cart);
        return cart;
    }

    public async Task<Cart> GetCart(string userId)
    {
        var isCartAvailable = await _carts.AnyAsync(cart => cart.UserId.Equals(userId));
        if (isCartAvailable)
        {
            return await _carts.SingleOrDefaultAsync(cart => cart.UserId.Equals(userId)) ?? new Cart();
        }

        // Create a new one if the cart doesn't exist.
        var cart = await Create(new Cart()
        {
            UserId = userId
        });
        return cart;

    }

    public async Task<bool> RemoveItemFromCart(string cartId, string itemId)
    {
        var cart = await _carts.SingleOrDefaultAsync(cart => cart.Id.Equals(cartId));

        if (cart is not null)
        {
            var item = cart.CartItems.FirstOrDefault(item => item.Id.Equals(itemId));
            if (item is not null)
            {
                cart.CartItems.Remove(item);
                await _carts.UpdateAsync(cart);
                return true;
            }
            return false;
        }

        return await Task.FromException<bool>(new Exception("User's cart not found"));
    }
}
