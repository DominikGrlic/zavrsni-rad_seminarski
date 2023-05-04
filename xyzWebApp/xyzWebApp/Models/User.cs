using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace xyzWebApp.Models;


public class User
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
