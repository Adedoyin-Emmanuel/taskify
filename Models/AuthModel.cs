namespace taskify.Models;

public class Auth
{

    public required Guid Id { get; set; }
    public required string Fullname { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

}