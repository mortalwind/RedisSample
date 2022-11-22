using Redis.OM.Modeling;

using System.ComponentModel.DataAnnotations;

namespace RedisSample.UserAPI.Models;


public class CartItem
{
    [Required]
    public string Id { get; set; } = $"{Guid.NewGuid()}";

    [Required]
    public string CartId { get; set; } = String.Empty;

    [Required]
    public string ProductId { get; set; } = String.Empty;

    [Required]
    public decimal Amount { get; set; }

    [Required]
    public int Quantity { get; set; }

    public decimal TotalAmount => Amount * Quantity;

}
