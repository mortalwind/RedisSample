using Redis.OM.Modeling;

using System.ComponentModel.DataAnnotations;

namespace RedisSample.UserAPI.Models;


[Document(StorageType = StorageType.Json, Prefixes = new[] { "User"})]
public class User
{

    [Required]
    [RedisIdField]
    [Indexed]
    public string Id { get; set; } = $"{Guid.NewGuid()}";

    [Required]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [Searchable]
    public string FullName { get; set; } = string.Empty;
}
