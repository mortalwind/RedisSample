using RedisSample.UserAPI.Models;

namespace RedisSample.UserAPI.Abstractions;

public interface IUsersRepository
{
    /// <summary>
    /// Adds a new user
    /// </summary>
    /// <param name="user">User info</param>
    /// <returns></returns>
    Task<User> Create(User user);

    /// <summary>
    /// Gets an user with id
    /// </summary>
    /// <param name="id">User's unique Id</param>
    /// <returns></returns>
    Task<User> GetUser(string id);

    /// <summary>
    /// Gets all users
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<User>> GetUsers();


    /// <summary>
    /// Updates an existing user 
    /// </summary>
    /// <param name="user">User's info</param>
    /// <returns></returns>
    Task<User> UpdateUser(User user);

}
