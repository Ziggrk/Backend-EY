using AutoMapper;
using Backend.API.Request;
using Backend.API.Response;
using Backend.Infrastructure.Interface;
using Backend.Infrastructure.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInfrastructure _userInfrastructure;
        private readonly IMapper _mapper;

        public UserController(IUserInfrastructure userInfrastructure, IMapper mapper)
        {
            _userInfrastructure = userInfrastructure;
            _mapper = mapper;
        }

        // GET api/user
        [HttpGet]
        public async Task<List<UserResponse>> GetAllAsync()
        {
            var users = await _userInfrastructure.GetAllAsync();
            var usersResponse = _mapper.Map<List<User>, List<UserResponse>>(users);
            return usersResponse;

        }

        [HttpPost]
        public async Task PostAsync([FromBody] UserRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<UserRequest, User>(request);

                await _userInfrastructure.SaveAsync(user);
            }
            else
            {
                StatusCode(400);
            }
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _userInfrastructure.DeleteAsync(id);
        }

        [HttpPost("auth")]
        public async Task<bool> LoginAsync([FromBody] UserRequest request)
        {
            var user = _mapper.Map<UserRequest, User>(request);
            return await _userInfrastructure.LoginAsync(user);
        }

    }
}
