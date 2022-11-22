using Microsoft.AspNetCore.Mvc;
using RedisSample.UserAPI.Abstractions;
using RedisSample.UserAPI.Models;

namespace RedisSample.UserAPI.Controllers;

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
    public async Task<ActionResult<IList<User>>> GetAllUsersAsync()
    {

        var users = await _repository.GetUsers();
       
        return Ok(users?.ToList());
    }

    [HttpGet]
    [Route("/{id}")]
    public async Task<ActionResult<User>> GetUserAsync([FromRoute]string id) {

        var user = await _repository.GetUser(id);
        if (user == null) {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<string> AddUserAsync([FromBody]User user)
    {
        await _repository.Create(user);
        return await Task.FromResult(user.Id);
    }
}
