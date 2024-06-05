using Microsoft.AspNetCore.Identity;

namespace taskify.Models;

public class User : IdentityUser<Guid>
{

    public required string Fullname { get; set; }


}