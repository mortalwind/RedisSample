using Redis.OM.Modeling;

using System.ComponentModel.DataAnnotations;

namespace RedisSample.API.Models;

public class Cart
{
    [Required]
    [Indexed]
    public string Id { get; set; } = $"{Guid.NewGuid}";

    [Required]
    [Indexed]
    [Searchable]
    public string UserId { get; set; } = string.Empty;

    [Required]
    [Indexed]
    public List<CartItem> CartItems { get; set; } = new List<CartItem>();

}
