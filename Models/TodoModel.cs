namespace taskify.Models;

public class Todo
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsDone { get; set; }
    public required Guid UserId { get; set; }

}