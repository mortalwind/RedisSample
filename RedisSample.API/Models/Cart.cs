using Redis.OM.Modeling;

using System.ComponentModel.DataAnnotations;

namespace RedisSample.API.Models;

[Document(StorageType = StorageType.Json, Prefixes = new[] { "carts" } )]
public class Cart
{
    [Required]
    [Indexed]
    [RedisIdField]
    public string Id { get; set; } = $"{Guid.NewGuid}";

    [Required]
    [Indexed]
    [Searchable]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [Indexed]
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

}
