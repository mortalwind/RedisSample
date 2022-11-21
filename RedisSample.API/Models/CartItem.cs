using Redis.OM.Modeling;

using System.ComponentModel.DataAnnotations;

namespace RedisSample.API.Models;

[Document(StorageType = StorageType.Json, Prefixes = new[] { "cartitems" })]
public class CartItem
{
    [Required]
    [Indexed]
    [RedisIdField]
    public string Id { get; set; } = $"{Guid.NewGuid()}";

    [Required]
    [Indexed]
    [Searchable]
    public string CartId { get; set; } = String.Empty;

    [Required]
    [Indexed]
    public string ProductId { get; set; } = String.Empty;

    [Required]
    [Indexed]
    public decimal Amount { get; set; }

    [Required]
    [Indexed]
    public int Quantity { get; set; }

    public decimal TotalAmount => Amount * Quantity;

}
