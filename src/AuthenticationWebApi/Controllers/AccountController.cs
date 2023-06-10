
using AuthenticationWebApi.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Partytime.Common.JwtAuthentication;
using Partytime.Common.JwtAuthentication.Models;
using Partytime.Party.Service.Repositories;

namespace AuthenticationWebApi.Controllers
{
    [Route("account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly IUseraccountRepository _useraccountRepository;

        public AccountController(JwtTokenHandler jwtTokenHandler, IUseraccountRepository useraccountRepository) 
        {
            _jwtTokenHandler = jwtTokenHandler;
            _useraccountRepository = useraccountRepository;
        }

        [HttpPost]
        public async Task<ActionResult<AuthenticationResponse>> Authentication([FromBody] AuthenticationRequest authenticationRequest)
        {
            var authenticationResponse = await _jwtTokenHandler.GenerateJwtToken(authenticationRequest);
            if (authenticationResponse == null) return Unauthorized();
            return authenticationResponse;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UseraccountDto>> Post([FromBody] CreateUseraccountDto createUseraccountDto)
        {
            var user = new Entities.Useraccount
            {
                Username = createUseraccountDto.Username,
                Email = createUseraccountDto.Email,
                Password = createUseraccountDto.Password
            };

            Entities.Useraccount createdUseraccount = await _useraccountRepository.CreateUser(user);

            return Ok();
        }

        [HttpPost("user")]
        public async Task<IActionResult> GetUser(GetUseraccountDto getUseraccountDto)
        {
            return Ok(getUseraccountDto.ToString());
            var jsonData = JsonConvert.DeserializeObject<GetUseraccountDto>(getUseraccountDto);
            var user = await _useraccountRepository.GetUser(getUseraccountDto.Username, getUseraccountDto.Password);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
