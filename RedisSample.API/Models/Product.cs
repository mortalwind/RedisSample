using System.ComponentModel.DataAnnotations;

namespace RedisSample.API.Models;

public class Product
{

    [Required]
    public string Id { get; set; } = $"products:{Guid.NewGuid()}";


    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }
}
