using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using DTO;
using AutoMapper;


namespace MyFirstWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        IUserService _userService;
        IMapper _mapper;

        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/<loginController>
        [HttpPost("login")]
        public async Task<ActionResult> Post([FromBody] UserEmailPassDTO userEmailPassDTO)
        {
            User user = await _userService.GetUserByUserNameAndPassword(userEmailPassDTO.Email, userEmailPassDTO.Password);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            if (user == null)
                return NoContent();
            return Ok(userDTO);
        }

        // GET api/<loginController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            User user = await _userService.GetUserById(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return userDTO;

        }

        // POST api/<loginController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserLoginDTO userLoginDTO)
        {
            User newUser = await _userService.AddUser(userLoginDTO);
            _logger.LogInformation("New user created. UserId: " + newUser.UserId);
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);
        }

        [HttpPost("checkPassword")]
        public ActionResult CheckPassword([FromBody] string pwd)
        {
            return Ok(_userService.checkpassword(pwd));
        }

        // PUT api/<loginController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> Put(int id, [FromBody] User userToUpdate)
        {

            return Ok(await _userService.UpdateUser(id, userToUpdate));
        }
    }
}
