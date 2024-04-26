using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using xyz_API.Models;

namespace xyz_API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    
    [HttpGet("Admin")]
    [Authorize(Roles = "Administrator")]
    public IActionResult AdminEndpoint()
    {
        var currentUser = GetCurrentUser();

        return Ok($"Hi {currentUser.GivenName}, you are {currentUser.Role}");
    }
    
    [HttpGet("Seller")]
    [Authorize(Roles = "Seller")]
    public IActionResult SellerEndpoint()
    {
        var currentUser = GetCurrentUser();

        return Ok($"Hi {currentUser.GivenName}, you are {currentUser.Role}");
    }
    
    [HttpGet("Buyer")]
    [Authorize(Roles = "Buyer")]
    public IActionResult BuyerEndpoint()
    {
        var currentUser = GetCurrentUser();

        return Ok($"Hi {currentUser.GivenName}, you are {currentUser.Role}");
    }
    
    
    [HttpGet("Public")]
    public IActionResult Index()
    {
        return Ok("Hi, you are on public property");
    }

    
    private UserModel GetCurrentUser()
    {
        var identity = HttpContext.User.Identity as ClaimsIdentity;

        if (identity != null)
        {
            var userClaims = identity.Claims;

            return new UserModel
            {
                UserName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                EmailAddress = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value,
                GivenName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.GivenName)?.Value,
                Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value
            };
        }

        return null;
    }
}