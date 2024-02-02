using financial_management_api.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace financial_management_api.Authentication
{
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Fluent.Infrastructure.FluentModel.RegisterViewModel model)
        {
            // Your registration logic using UserManager
            // Example: Creating a new user
            var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                // Automatically sign in the user after registration
                await _signInManager.SignInAsync(newUser, isPersistent: false);

                // Generate token
                var tokenResult = await _userManager.GenerateUserTokenAsync(newUser, TokenOptions.DefaultProvider, "emailconfirmation");

                // TODO: Return token or any other response
                return Ok(new { Message = "Registration successful", Token = tokenResult });
            }

            // TODO: Handle registration failure
            return BadRequest(new { Message = "Registration failed", result.Errors });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            // Your login logic using SignInManager
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                // Generate token
                var user = await _userManager.FindByEmailAsync(model.Email);
                var tokenResult = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultProvider, "login");

                // TODO: Return token or any other response
                return Ok(new { Message = "Login successful", Token = tokenResult });
            }

            // TODO: Handle login failure
            return Unauthorized(new { Message = "Invalid email or password" });
        }
    }
}