using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcomProject.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EcomProject.BL.DTOs.Auth;
using EcomProject.BL.Manager.Auth;

namespace EcomProject.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly AuthManager authManager;

        public UserController(IConfiguration configuration,
            UserManager<DAL.Models.User> userManager,
            AuthManager authManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            this.authManager = authManager;
        }
        [HttpPost("login")]
        public async Task<Results<Ok, ProblemHttpResult>> Login(LoginDTO loginDTO)
        {
            var result = await authManager.LoginAsync(loginDTO);

            if (result.StartsWith("please") || result.StartsWith("Wrong"))
            {
                // Create a ProblemDetails object to hold the error information
                var problemDetails = new ProblemDetails
                {
                    // The status code you want to return
                    Status = StatusCodes.Status401Unauthorized,
                    // The main, user-facing error message
                    Title = "Authentication Failed",
                    // Your specific result string goes here
                    Detail = result
                };
                return TypedResults.Problem(problemDetails);
            }



                Response.Cookies.Append("token", result, new CookieOptions
            {
                Secure = true,
                HttpOnly = true,
                Domain = "localhost",
                Expires = DateTime.Now.AddDays(1),
                IsEssential = true,
                SameSite = SameSiteMode.Strict,
            });
            return TypedResults.Ok();
            //var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            //if (user == null)
            //{
            //    return TypedResults.Unauthorized();
            //}

            //var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            //if (!isPasswordValid)
            //{
            //    return TypedResults.Unauthorized();
            //}

            //var claims = await _userManager.GetClaimsAsync(user);
            //var Token = GenerateToken(claims.ToList());

            //return TypedResults.Ok(Token);
        }

        [HttpPost("register")]

        public async Task<Results<NoContent, BadRequest<string>>> Register(RegisterDTO registerDTO)
        {
            var result = await authManager.RegisterAsync(registerDTO);
            if (result != "done")
            {
                return TypedResults.BadRequest(result);
            }
            return TypedResults.NoContent();
            //var user = new User
            //{
            //    Id = Guid.NewGuid(),
            //    UserName = registerDTO.UserName,
            //    Email = registerDTO.Email,
            //    FirstName = registerDTO.FirstName,
            //    LastName = registerDTO.LastName,
            //};

            //var creationResult = await _userManager.CreateAsync(user, registerDTO.Password);

            //if (!creationResult.Succeeded)
            //{
            //    var errors = creationResult.Errors.Select(e => e.Description).ToList();
            //    return TypedResults.BadRequest(errors);
            //}

            //var claims = new List<Claim>
            //{
            //    new Claim (ClaimTypes.NameIdentifier, user.Id.ToString()),
            //    new Claim(ClaimTypes.Email,user.Email),
            //    new Claim(ClaimTypes.Name,user.UserName),

            //};

            //await _userManager.AddClaimsAsync(user, claims);

            //return TypedResults.NoContent();
        }

        [HttpPost("active-account")]

        public async Task<IActionResult> Active (ActiveAccount activeAccountDto)
        {
            var result = await authManager.ActiveAccount(activeAccountDto);

            return result ? Ok(result) : BadRequest(result);
        }

        [HttpGet("forget-password")]

        public async Task<IActionResult> ForgetPassword(string email)
        {
            var result = await authManager.SendEmailForForger(email);
            return result ? Ok(result) : BadRequest(result);

        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword (ResetPassword resetPasswordDto)
        {
            var result = await authManager.ResetPassword(resetPasswordDto);
            if (result.StartsWith("Password"))
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        //private TokenDTO GenerateToken(List<Claim> claims)
        //{
        //    var secretKey = _configuration.GetValue<string>("SecretKey");
        //    var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
        //    var key = new SymmetricSecurityKey(secretKeyBytes);

        //    var creds = new SigningCredentials(
        //        key,
        //        SecurityAlgorithms.HmacSha256);
        //    var expires = DateTime.Now.AddHours(1);

        //    var token = new JwtSecurityToken(

        //        claims: claims,
        //        expires: expires,
        //        signingCredentials: creds);
        //    var ToKenString = new JwtSecurityTokenHandler().WriteToken(token);
        //    return new TokenDTO(ToKenString, token.ValidTo);
        //}

    }


}

