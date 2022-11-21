using Redis.OM.Modeling;

using System.ComponentModel.DataAnnotations;

namespace RedisSample.API.Models;


[Document(StorageType = StorageType.Json, Prefixes = new[] { "users"})]
public class User
{

    [Required]
    [RedisIdField]
    [Indexed]
    public string Id { get; set; } = $"{Guid.NewGuid()}";


    [Required]
    [Indexed]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [Searchable]
    public string FullName { get; set; } = string.Empty;
}
