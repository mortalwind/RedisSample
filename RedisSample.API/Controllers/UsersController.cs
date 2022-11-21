using Microsoft.AspNetCore.Mvc;
using RedisSample.API.Abstractions;
using RedisSample.API.Models;

namespace RedisSample.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _repository;

    public UsersController(IUsersRepository repository)
	{
        _repository = repository;

    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<User> GetUserAsync([FromRoute]string id) {

        var user = await _repository.GetUser(id);
        return await Task.FromResult(user);
    }

    [HttpPost]
    public async Task<string> AddUserAsync([FromBody]User user)
    {
        await _repository.Create(user);
        return await Task.FromResult(user.Id);
    }
}
