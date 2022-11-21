using Redis.OM;
using Redis.OM.Searching;
using RedisSample.API.Abstractions;
using RedisSample.API.Models;
namespace RedisSample.API.Data;

public class UsersRepository : IUsersRepository
{

    private readonly RedisConnectionProvider _provider;
    private readonly RedisCollection<User> _users;

    public UsersRepository(RedisConnectionProvider provider)
    {
        _provider = provider;
        _users = (RedisCollection<User>)provider.RedisCollection<User>();
    }

    public async Task<User> Create(User user)
    {
        if (user is null)
        {
            return await Task.FromException<User>(new ArgumentOutOfRangeException(nameof(user)));
        }
        await _users.InsertAsync(user);

        return user;
    }

    public async Task<User> GetUser(string id)
    {
        return await _users.SingleOrDefaultAsync(user => user.Id ==id);
        
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _users.ToListAsync() ?? new List<User>();
    }

    public async Task<User> UpdateUser(User user)
    {
        if (user is null)
        {
            return await Task.FromException<User>(new ArgumentOutOfRangeException(nameof(user)));
        }
        await _users.UpdateAsync(user);
       return await GetUser(user.Id);
    }
}
