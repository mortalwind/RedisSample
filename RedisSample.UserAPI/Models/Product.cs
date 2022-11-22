using Redis.OM.Modeling;
using System.ComponentModel.DataAnnotations;

namespace RedisSample.UserAPI.Models;

public class Product
{

    [Required]
    [Indexed]
    public string Id { get; set; } = $"{Guid.NewGuid()}";


    [Required]
    [Indexed]
    [Searchable]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }
}
